namespace EFSoft.BFF.Application.Customers.UpdateCustomer;

public sealed record UpdateCustomerCommand(
         Guid CustomerId,
         string FullName,
         DateTimeOffset DateOfBirth) : ICommand;
