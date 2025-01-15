namespace EFSoft.BFF.Api.Customers.GetCustomers;

public sealed record GetCustomersRequest(IEnumerable<Guid> CustomerIds);
