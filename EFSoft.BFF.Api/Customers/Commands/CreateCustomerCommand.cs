namespace EFSoft.BFF.Api.Customers.Commands;

public sealed record class CreateCustomerCommand(
         string FullName,
         DateTimeOffset DateOfBirth)
{
}
