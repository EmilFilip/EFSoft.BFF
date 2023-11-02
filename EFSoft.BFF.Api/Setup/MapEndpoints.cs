namespace EFSoft.BFF.Api.Setup;

public static class ConfigureEndpoints
{
    [ExcludeFromCodeCoverage]
    public static void MapLocalEndpoints(this WebApplication app)
    {
        app.MapCustomerEndpoints();
        //app.MapOrderEndpoints();
        //app.MapInventoryEndpoints();
        //app.MapProductEndpoints();
    }
}
