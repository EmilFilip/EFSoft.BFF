namespace EFSoft.BFF.Application.Customers.GetCustomer;

public sealed record GetCustomerQuery(Guid CustomerId)
    : IQuery<GetCustomerQueryResult?>;
