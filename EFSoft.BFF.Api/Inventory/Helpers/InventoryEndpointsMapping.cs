namespace EFSoft.BFF.Api.Inventory.Helpers;

public class InventoryEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("inventory")
            .WithTags(FeatureFlags.Inventory)
            .AddEndpointFilter(new FeatureFlagEndpointFilter(FeatureFlags.Inventory));
        //.RequireAuthorization();

        _ = group.MapGet("/{productId:guid}", GetInventoryEndpoint.GetInventory)
            .MapToApiVersion(1);

        _ = group.MapPost("/", CreateInventoryEndpoint.CreateInventory)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<CreateInventoryRequest>>();

        _ = group.MapPut("/", UpdateInventoryEndpoint.UpdateInventory)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<UpdateInventoryRequest>>();
    }
}
