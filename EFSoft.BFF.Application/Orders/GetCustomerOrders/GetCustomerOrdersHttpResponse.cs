namespace EFSoft.BFF.Application.Orders.GetCustomerOrders;

public class GetCustomerOrdersHttpResponse
{
    [JsonPropertyName("orders")]
    public IEnumerable<OrderDomainModel> Orders { get; set; }
}
