namespace EFSoft.BFF.Application.Customers.GetCustomers;

public class GetCustomersHttpResponse
{
    [JsonPropertyName("customers")]
    public IEnumerable<CustomerModel>? Customers { get; set; }
}
