using EFSoft.BFF.Api.Orders.CreateOrder;
namespace EFSoft.BFF.Api.Orders.Helpers;

public class OrdersEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/order").WithTags("Orders");

        _ = group.MapGet("{orderId:guid}", GetOrderEndpoint.Get);

        _ = group.MapGet("get-customer-orders/{customerId:guid}", GetCustomerOrdersEndpoint.GetCustomerOrders);

        _ = group.MapPost("", CreateOrderEndpoint.Post)
            .AddEndpointFilter<ValidationFilter<CreateOrderRequestValidator>>();

        _ = group.MapPut("", UpdateOrderEndpoint.Put)
            .AddEndpointFilter<ValidationFilter<UpdateOrderRequestValidator>>();

        _ = group.MapPut("status", UpdateOrderStatusEndpoint.Put)
            .AddEndpointFilter<ValidationFilter<UpdateOrderStatusRequestValidator>>();
    }
}
