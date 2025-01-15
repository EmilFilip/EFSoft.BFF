namespace EFSoft.BFF.Application.Orders.UpdateOrderStatus;

public sealed record UpdateOrderStatusCommand(
    Guid OrderId,
    OrderStatus OrderStatus) : ICommand;
