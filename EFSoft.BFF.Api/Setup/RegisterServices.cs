namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterServices
{
    public static IServiceCollection RegisterLocalServices(
                this IServiceCollection services,
                IConfiguration configuration)
    {
        return services
             .RegisterCqrs(typeof(GetCustomerQuery).Assembly)
             //Customers
             .AddScoped<ICreateCustomerRepository, CreateCustomerRepository>()
             .AddScoped<IDeleteCustomerRepository, DeleteCustomerRepository>()
             .AddScoped<IGetCustomerRepository, GetCustomerRepository>()
             .AddScoped<IGetCustomersRepository, GetCustomersRepository>()
             .AddScoped<IGetAllCustomersRepository, GetAllCustomersRepository>()
             .AddScoped<IUpdateCustomerRepository, UpdateCustomerRepository>()
             //Products
             .AddScoped<ICreateProductRepository, CreateProductRepository>()
             .AddScoped<IDeleteProductRepository, DeleteProductRepository>()
             .AddScoped<IGetProductRepository, GetProductRepository>()
             .AddScoped<IGetProductsRepository, GetProductsRepository>()
             .AddScoped<IUpdateProductRepository, UpdateProductRepository>()
             //Orders
             .AddScoped<ICreateOrderProductRepository, CreateOrderProductRepository>()
             .AddScoped<ICreateOrderRepository, CreateOrderRepository>()
             .AddScoped<IGetCustomerOrdersRepository, GetCustomerOrdersRepository>()
             .AddScoped<IGetOrderProductsForOrderRepository, GetOrderProductsForOrderRepository>()
             .AddScoped<IGetProductsWithOrderByOrderIdRepository, GetProductsWithOrderByOrderIdRepository>()
             .AddScoped<IGetOrderRepository, GetOrderRepository>()
             .AddScoped<IUpdateOrderProductsRepository, UpdateOrderProductsRepository>()
             .AddScoped<IUpdateOrderRepository, UpdateOrderRepository>()
             .AddScoped<IUpdateOrderStatusRepository, UpdateOrderStatusRepository>()
             //Inventory
             .AddScoped<ICreateProductInventoryRepository, CreateProductInventoryRepository>()
             .AddScoped<IGetProductInventoryRepository, GetProductInventoryRepository>()
             .AddScoped<IUpdateProductInventoryRepository, UpdateProductInventoryRepository>();
    }
}
