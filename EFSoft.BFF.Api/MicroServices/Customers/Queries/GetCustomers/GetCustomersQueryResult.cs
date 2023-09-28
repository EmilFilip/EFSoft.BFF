using EFSoft.BFF.Api.MicroServices.Customers.Models;

namespace EFSoft.BFF.Api.MicroServices.Customers.Queries.GetCustomers;

public class GetCustomersQueryResult
{
    public GetCustomersQueryResult(IEnumerable<CustomerModel> customers)
    {
        Customers = customers;
    }

    public IEnumerable<CustomerModel> Customers { get; }
}
