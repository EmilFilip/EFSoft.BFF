namespace EFSoft.BFF.Api.Customers.UpdateCustomer;

public sealed record UpdateCustomerRequest(
     Guid CustomerId,
     string FullName,
     DateTimeOffset DateOfBirth);
