namespace EFSoft.BFF.Domain.Orders.Models;

public class OrderProductModel
{
    [JsonPropertyName("orderProductId")]
    public Guid OrderProductId { get; set; }

    [JsonPropertyName("orderId")]
    public Guid OrderId { get; set; }

    [JsonPropertyName("productId")]
    public Guid ProductId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}
