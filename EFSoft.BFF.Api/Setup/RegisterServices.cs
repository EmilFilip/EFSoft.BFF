namespace EFSoft.BFF.Api.Setup;

[ExcludeFromCodeCoverage]
public static class RegisterServices
{
    public static IServiceCollection RegisterLocalServices(
                this IServiceCollection services,
                IConfiguration configuration)
    {
        return services;
             //.RegisterCqrs(typeof(GetCustomerQuery).Assembly);
    }
}
