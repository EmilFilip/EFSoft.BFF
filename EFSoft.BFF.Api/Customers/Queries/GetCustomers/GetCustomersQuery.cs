namespace EFSoft.BFF.Api.Customers.GetCustomers;

public sealed record GetCustomersQuery(IEnumerable<Guid> CustomerIds)
{
}
