namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterHttpClient
{
    public static IHttpClientBuilder AddHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        string customersServiceBaseAddress = configuration["CustomersService:CustomersServiceBaseAddress"] ?? throw new ConfigNotFoundException("CustomersServiceBaseAddress is either null or empty");

        var builder = serviceCollection.AddHttpClient(Api.Constants.HttpClientConstants.CustomersServiceHttpCientName, x =>
        {
            x.BaseAddress = new Uri(customersServiceBaseAddress);
            x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Api.Constants.HttpClientConstants.HttpCientApplicationUrlencodedAcceptHeader));
        });

        return builder;
    }
}
