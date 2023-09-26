namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterHttpClient
{
    public static IHttpClientBuilder RegisterHttpClientBuilder(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        string customersServiceBaseAddress = configuration["CustomersService:CustomersServiceBaseAddress"] ?? throw new ConfigNotFoundException("CustomersServiceBaseAddress is either null or empty");
        //string subscriptionKey = configuration["CustomersService:AppCode"] ?? throw new ConfigNotFoundException("AppCode is either null or empty");

        var builder = serviceCollection.AddHttpClient(Api.Constants.HttpClientConstants.CustomersServiceHttpCientName, x =>
        {
            x.BaseAddress = new Uri(customersServiceBaseAddress);
            x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Api.Constants.HttpClientConstants.HttpCientApplicationUrlencodedAcceptHeader));
            //x.DefaultRequestHeaders.Add("AppCode", subscriptionKey);
        }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

        });

        return builder;
    }
}
