namespace EFSoft.BFF.Application.Customers.GetAllCustomers;

public class GetAllCustomersHttpResponse
{
    [JsonPropertyName("pagedList")]
    public PagedList<CustomerModel>? PagedList { get; set; }
}
