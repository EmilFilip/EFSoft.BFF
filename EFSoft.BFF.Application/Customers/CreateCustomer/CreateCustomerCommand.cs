namespace EFSoft.BFF.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(
    string FullName,
    DateTimeOffset DateOfBirth) : ICommand;
