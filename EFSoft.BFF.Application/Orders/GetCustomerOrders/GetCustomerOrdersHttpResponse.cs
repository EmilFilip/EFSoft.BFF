namespace EFSoft.BFF.Application.Orders.GetCustomerOrders;

public class GetCustomerOrdersHttpResponse
{
    [JsonPropertyName("orders")]
    public IEnumerable<OrderModel> Orders { get; set; }
}
