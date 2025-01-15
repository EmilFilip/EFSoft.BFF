namespace EFSoft.BFF.Application.Orders.GetOrder;

public class GetOrderQueryResult
{
    public GetOrderQueryResult(OrderDomainModel order)
    {
        Order = order;
    }

    public OrderDomainModel Order { get; }
}
