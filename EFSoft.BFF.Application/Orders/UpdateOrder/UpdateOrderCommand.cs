namespace EFSoft.BFF.Application.Orders.UpdateOrder;

public sealed record UpdateOrderCommand(
         Guid OrderId,
         string Description,
         IEnumerable<OrderProductCreate> OrderProducts) : ICommand;
