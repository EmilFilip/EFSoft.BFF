namespace EFSoft.BFF.Application.Orders.CreateOrder;

public sealed record OrderProductCreateDto(
         Guid ProductId,
         int Quantity);
