namespace EFSoft.BFF.Api.MicroServices.Orders.Commands;

public sealed record class CreateOrderCommand(
         Guid CustomerId,
         string Description,
         IEnumerable<OrderCreate> OrderProducts);
