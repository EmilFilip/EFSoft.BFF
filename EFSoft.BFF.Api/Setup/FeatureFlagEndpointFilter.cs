namespace EFSoft.BFF.Api.Setup;

public class FeatureFlagEndpointFilter(string endpoint) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var featureManager = context.HttpContext.RequestServices.GetService<IFeatureManager>();

        var isEnabled = await featureManager.IsEnabledAsync(endpoint);

        if (isEnabled)
        {
            return await next(context);
        }

        return Results.NotFound();
    }
}
