namespace EFSoft.BFF.Api.MicroServices.Orders.Commands;

public sealed record class UpdateOrderCommand(
         Guid OrderId,
         Guid CustomerId,
         string Description,
         OrderStatus OrderStatus,
         IEnumerable<OrderProduct> OrderProducts);
