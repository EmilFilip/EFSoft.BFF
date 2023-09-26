namespace EFSoft.BFF.Api.Customers.GetCustomers;

public class GetCustomersQueryResult
{
    public GetCustomersQueryResult(IEnumerable<CustomerModel> customers)
    {
        Customers = customers;
    }

    public IEnumerable<CustomerModel> Customers { get; }
}
