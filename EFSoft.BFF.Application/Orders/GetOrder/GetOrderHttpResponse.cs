namespace EFSoft.BFF.Application.Orders.GetOrder;

public class GetOrderHttpResponse
{
    [JsonPropertyName("order")]
    public OrderDomainModel Order { get; set; }
}
