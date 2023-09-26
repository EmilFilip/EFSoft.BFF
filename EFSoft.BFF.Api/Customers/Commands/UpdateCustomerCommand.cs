namespace EFSoft.BFF.Api.Customers.Commands;

public sealed record UpdateCustomerCommand(
         Guid CustomerId,
         string FullName,
         DateTimeOffset DateOfBirth)
{
}
