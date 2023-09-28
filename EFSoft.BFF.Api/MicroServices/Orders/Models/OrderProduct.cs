namespace EFSoft.BFF.Api.MicroServices.Orders.Models;

public sealed record class OrderProduct(
     Guid orderProductId,
     Guid orderId,
     Guid productId,
     int quantity);
