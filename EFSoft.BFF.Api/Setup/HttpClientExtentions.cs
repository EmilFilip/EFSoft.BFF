namespace EFSoft.BFF.Api.Setup;

public static class HttpClientExtentions
{
    public static IHttpResiliencePipelineBuilder AddCustomResilienceHandler(this IHttpClientBuilder builder)
    {
        return builder.AddResilienceHandler("custom", pipeline =>
        {
            _ = pipeline.AddRetry(new HttpRetryStrategyOptions
            {
                MaxRetryAttempts = 3,
                BackoffType = DelayBackoffType.Exponential,
                UseJitter = true,
                Delay = TimeSpan.FromMilliseconds(500)
            });
            _ = pipeline.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
            {
                SamplingDuration = TimeSpan.FromSeconds(10),
                FailureRatio = 0.9,
                MinimumThroughput = 5,
                BreakDuration = TimeSpan.FromSeconds(5)
            });
            _ = pipeline.AddTimeout(TimeSpan.FromSeconds(100));
        });
    }
}
