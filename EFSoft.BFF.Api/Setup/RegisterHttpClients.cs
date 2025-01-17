namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterHttpClient
{
    public static void AddLocalHttpClients(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        _ = serviceCollection.AddCustomersHttpClient(configuration);
        _ = serviceCollection.AddInventoryHttpClient(configuration);
        _ = serviceCollection.AddOrdersHttpClient(configuration);
        _ = serviceCollection.AddProductsHttpClient(configuration);
    }

    public static IHttpClientBuilder AddCustomersHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        var customersServiceBaseAddress = configuration["Microservices:CustomersServiceBaseAddress"] ?? throw new ConfigNotFoundException("CustomersServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClient.CustomersServiceHttpCientName, x =>
        {
            x.BaseAddress = new Uri(customersServiceBaseAddress);
            x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClient.HttpCientApplicationUrlencodedAcceptHeader));
        });

        return builder;
    }

    public static IHttpClientBuilder AddInventoryHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        var ordersServiceBaseAddress = configuration["Microservices:InventoryServiceBaseAddress"] ?? throw new ConfigNotFoundException("InventoryServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClient.InventoryServiceHttpCientName, x =>
            {
                x.BaseAddress = new Uri(ordersServiceBaseAddress);
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClient.HttpCientApplicationUrlencodedAcceptHeader));
            });

        return builder;
    }

    public static IHttpClientBuilder AddOrdersHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        var ordersServiceBaseAddress = configuration["Microservices:OrdersServiceBaseAddress"] ?? throw new ConfigNotFoundException("OrdersServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClient.OrdersServiceHttpCientName, x =>
            {
                x.BaseAddress = new Uri(ordersServiceBaseAddress);
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClient.HttpCientApplicationUrlencodedAcceptHeader));
            });

        return builder;
    }

    public static IHttpClientBuilder AddProductsHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        var productsServiceBaseAddress = configuration["Microservices:ProductsServiceBaseAddress"] ?? throw new ConfigNotFoundException("ProductsServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClient.ProductsServiceHttpCientName, x =>
            {
                x.BaseAddress = new Uri(productsServiceBaseAddress);
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClient.HttpCientApplicationUrlencodedAcceptHeader));
            });

        return builder;
    }
}
