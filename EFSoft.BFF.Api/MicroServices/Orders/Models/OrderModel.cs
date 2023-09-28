namespace EFSoft.BFF.Api.MicroServices.Orders.Models;

public sealed record OrderModel(
        Guid orderId,
        Guid customerId,
        string description,
        OrderStatus orderStatus);
