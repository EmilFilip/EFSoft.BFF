namespace EFSoft.BFF.Application.Orders.CreateOrder;

public sealed record OrderProductCreate(
         Guid ProductId,
         int Quantity);
