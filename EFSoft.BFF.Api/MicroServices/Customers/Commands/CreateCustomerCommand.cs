namespace EFSoft.BFF.Api.MicroServices.Customers.Commands;

public sealed record class CreateCustomerCommand(
         string FullName,
         DateTimeOffset DateOfBirth);
