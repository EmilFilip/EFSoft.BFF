namespace EFSoft.BFF.Api.MicroServices.Customers.Queries.GetCustomers;

public sealed record GetCustomersQuery(IEnumerable<Guid> CustomerIds);
