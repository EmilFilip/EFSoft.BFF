namespace EFSoft.BFF.Application.Orders.GetOrder;

public sealed record GetOrderQuery(Guid OrderId) : IQuery<GetOrderQueryResult>;
