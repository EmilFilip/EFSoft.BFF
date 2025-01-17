namespace EFSoft.BFF.Application.Orders.GetCustomerOrders;

public sealed record GetCustomerOrdersQueryResult(IEnumerable<OrderDomainModel> Orders);

