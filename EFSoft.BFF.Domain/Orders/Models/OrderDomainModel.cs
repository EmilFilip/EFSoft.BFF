namespace EFSoft.BFF.Domain.Orders.Models;

public class OrderDomainModel
{
    [JsonPropertyName("orderId")]
    public Guid OrderId { get; set; }

    [JsonPropertyName("customerId")]
    public Guid CustomerId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("orderStatus")]
    public OrderStatus OrderStatus { get; set; }

    [JsonPropertyName("orderProducts")]
    public IEnumerable<OrderProductDomainModel> OrderProducts { get; set; }
}
