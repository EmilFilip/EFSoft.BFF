namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterHttpClient
{
    public static void AddLocalHttpClients(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        _ = serviceCollection.AddCustomersHttpClient(configuration);
        _ = serviceCollection.AddOrdersHttpClient(configuration);
        _ = serviceCollection.AddInventoryHttpClient(configuration);
        _ = serviceCollection.AddProductsHttpClient(configuration);
    }

    public static IHttpClientBuilder AddCustomersHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        string customersServiceBaseAddress = configuration["CustomersService:CustomersServiceBaseAddress"] ?? throw new ConfigNotFoundException("CustomersServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClientConstants.CustomersServiceHttpCientName, x =>
        {
            x.BaseAddress = new Uri(customersServiceBaseAddress);
            x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClientConstants.HttpCientApplicationUrlencodedAcceptHeader));
        });

        return builder;
    }

    public static IHttpClientBuilder AddOrdersHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        string ordersServiceBaseAddress = configuration["OrdersService:OrdersServiceBaseAddress"] ?? throw new ConfigNotFoundException("OrdersServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClientConstants.OrdersServiceHttpCientName, x =>
            {
                x.BaseAddress = new Uri(ordersServiceBaseAddress);
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClientConstants.HttpCientApplicationUrlencodedAcceptHeader));
            });

        return builder;
    }

    public static IHttpClientBuilder AddInventoryHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        string ordersServiceBaseAddress = configuration["InventoryService:InventoryServiceBaseAddress"] ?? throw new ConfigNotFoundException("InventoryServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClientConstants.InventoryServiceHttpCientName, x =>
            {
                x.BaseAddress = new Uri(ordersServiceBaseAddress);
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClientConstants.HttpCientApplicationUrlencodedAcceptHeader));
            });

        return builder;
    }

    public static IHttpClientBuilder AddProductsHttpClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        string productsServiceBaseAddress = configuration["ProductsService:ProductsServiceBaseAddress"] ?? throw new ConfigNotFoundException("ProductsServiceBaseAddress is either null or empty");

        var builder = serviceCollection
            .AddHttpClient(Constants.HttpClientConstants.ProductsServiceHttpCientName, x =>
            {
                x.BaseAddress = new Uri(productsServiceBaseAddress);
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.HttpClientConstants.HttpCientApplicationUrlencodedAcceptHeader));
            });

        return builder;
    }
}