namespace EFSoft.BFF.Api.Customers.CreateCustomer;

public sealed record CreateCustomerRequest(
     string FullName,
     DateTimeOffset DateOfBirth);
