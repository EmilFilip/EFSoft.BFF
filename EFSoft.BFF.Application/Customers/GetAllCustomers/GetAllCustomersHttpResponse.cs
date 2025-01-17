namespace EFSoft.BFF.Application.Customers.GetAllCustomers;

public class GetCustomersHttpResponse
{
    [JsonPropertyName("pagedList")]
    public PagedList<CustomerModel> PagedList { get; set; }
}
