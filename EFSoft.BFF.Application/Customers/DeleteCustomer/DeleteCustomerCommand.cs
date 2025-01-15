namespace EFSoft.BFF.Application.Customers.DeleteCustomer;

public sealed record DeleteCustomerCommand(Guid CustomerId) : ICommand;
