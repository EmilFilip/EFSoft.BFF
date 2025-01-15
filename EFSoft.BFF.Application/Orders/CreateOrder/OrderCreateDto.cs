namespace EFSoft.BFF.Application.Orders.CreateOrder;

public sealed record OrderCreateDto(
         Guid ProductId,
         int Quantity);
