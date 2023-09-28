namespace EFSoft.BFF.Api.MicroServices.Orders.Queries.GetCustomerOrders;

public class GetCustomerOrdersQueryResult
{
    public GetCustomerOrdersQueryResult(IEnumerable<OrderModel> orders)
    {
        Orders = orders;
    }

    public IEnumerable<OrderModel> Orders { get; }
}
