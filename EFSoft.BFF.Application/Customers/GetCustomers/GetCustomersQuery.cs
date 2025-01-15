namespace EFSoft.BFF.Application.Customers.GetCustomers;

public sealed record GetCustomersQuery(IEnumerable<Guid> CustomerIds)
    : IQuery<GetCustomersQueryResult>;
