namespace EFSoft.BFF.Application.Orders.GetCustomerOrders;

public sealed record GetCustomerOrdersQuery(Guid CustomerId) : IQuery<GetCustomerOrdersQueryResult>;
