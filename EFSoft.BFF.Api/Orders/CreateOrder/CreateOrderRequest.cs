namespace EFSoft.BFF.Api.Orders.CreateOrder;

public sealed record CreateOrderRequest(
         Guid CustomerId,
         string Description,
         IEnumerable<OrderCreateDto> OrderProducts);
