namespace EFSoft.BFF.Application.Customers.GetCustomer;

public sealed record GetCustomerQueryResult(
    Guid CustomerId,
    string FullName,
    DateTimeOffset DateOfBirth,
    bool HasOpenedOrder);
