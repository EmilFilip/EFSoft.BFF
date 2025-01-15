namespace EFSoft.BFF.Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(
         Guid CustomerId,
         string Description,
         IEnumerable<OrderCreateDto> OrderProducts) : ICommand;
