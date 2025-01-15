namespace EFSoft.BFF.Application.Customers.GetCustomers;

public sealed record GetCustomersQueryResult(IEnumerable<CustomerDomainModel> Customers);
