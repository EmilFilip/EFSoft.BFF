namespace EFSoft.BFF.Api.Orders.UpdateOrder;

public sealed record UpdateOrderRequest(
         Guid OrderId,
         string Description,
         IEnumerable<OrderProductCreate> OrderProducts);
