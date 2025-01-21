namespace EFSoft.BFF.Api.Orders.Helpers;

public class OrdersEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("order")
            .WithTags(FeatureFlags.Orders)
            .AddEndpointFilter(new FeatureFlagEndpointFilter(FeatureFlags.Orders));
        //.RequireAuthorization();

        _ = group.MapGet("{orderId:guid}", GetOrderEndpoint.Get)
            .MapToApiVersion(1);

        _ = group.MapGet("get-customer-orders/{customerId:guid}", GetCustomerOrdersEndpoint.GetCustomerOrders)
            .MapToApiVersion(1);

        _ = group.MapPost("", CreateOrderEndpoint.Post)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<CreateOrderRequestValidator>>();

        _ = group.MapPut("", UpdateOrderEndpoint.Put)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<UpdateOrderRequestValidator>>();

        _ = group.MapPut("status", UpdateOrderStatusEndpoint.Put)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<UpdateOrderStatusRequestValidator>>();
    }
}
