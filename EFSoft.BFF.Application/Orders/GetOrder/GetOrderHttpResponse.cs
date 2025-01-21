namespace EFSoft.BFF.Application.Orders.GetOrder;

public class GetOrderHttpResponse
{
    [JsonPropertyName("order")]
    public OrderModel? Order { get; set; }
}
