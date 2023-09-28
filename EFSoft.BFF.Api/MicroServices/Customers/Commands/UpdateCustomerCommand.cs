namespace EFSoft.BFF.Api.MicroServices.Customers.Commands;

public sealed record UpdateCustomerCommand(
         Guid CustomerId,
         string FullName,
         DateTimeOffset DateOfBirth);