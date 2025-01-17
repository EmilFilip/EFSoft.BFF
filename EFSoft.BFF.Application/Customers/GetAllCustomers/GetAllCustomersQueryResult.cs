namespace EFSoft.BFF.Application.Customers.GetAllCustomers;

public sealed record GetAllCustomersQueryResult(PagedList<CustomerModel> PagedList);
