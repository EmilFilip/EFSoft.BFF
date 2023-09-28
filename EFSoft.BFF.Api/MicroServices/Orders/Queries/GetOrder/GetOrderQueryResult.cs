namespace EFSoft.BFF.Api.MicroServices.Orders.Queries.GetOrder;

public class GetOrderQueryResult
{
    public GetOrderQueryResult(OrderModel order)
    {
        Order = order;
    }

    public OrderModel Order { get; }
}