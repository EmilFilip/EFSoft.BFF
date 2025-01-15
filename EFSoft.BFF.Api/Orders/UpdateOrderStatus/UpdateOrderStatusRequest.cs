namespace EFSoft.BFF.Api.Orders.UpdateOrderStatus;

public sealed record UpdateOrderStatusRequest(
    Guid OrderId,
    OrderStatus OrderStatus);

