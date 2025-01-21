namespace EFSoft.BFF.Api.Inventory.Helpers;

public class InventoryEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/inventory").WithTags(FeatureFlags.Inventory)
            .AddEndpointFilter(new FeatureFlagEndpointFilter(FeatureFlags.Inventory));
        //.RequireAuthorization();

        _ = group.MapGet("/{productId:guid}", GetInventoryEndpoint.GetInventory);

        _ = group.MapPost("/", CreateInventoryEndpoint.CreateInventory)
            .AddEndpointFilter<ValidationFilter<CreateInventoryRequest>>();

        _ = group.MapPut("/", UpdateInventoryEndpoint.UpdateInventory)
            .AddEndpointFilter<ValidationFilter<UpdateInventoryRequest>>();
    }
}
