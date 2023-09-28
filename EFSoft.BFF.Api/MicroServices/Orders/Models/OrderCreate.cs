namespace EFSoft.BFF.Api.MicroServices.Orders.Models;

public sealed record class OrderCreate(
         Guid ProductId,
         int Quantity);
