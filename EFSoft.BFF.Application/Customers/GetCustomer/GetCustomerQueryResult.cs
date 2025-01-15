namespace EFSoft.BFF.Application.Customers.GetCustomer;

public sealed record GetCustomerQueryResult(
        string FullName,
        DateTimeOffset DateOfBirth);
