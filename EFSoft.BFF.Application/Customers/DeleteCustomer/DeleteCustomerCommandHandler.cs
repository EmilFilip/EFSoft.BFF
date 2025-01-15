namespace EFSoft.BFF.Application.Customers.DeleteCustomer;

public class DeleteCustomerCommandHandler(IDeleteCustomerRepository deleteCustomerRepository)
    : ICommandHandler<DeleteCustomerCommand>
{
    public async Task Handle(
        DeleteCustomerCommand command,
        CancellationToken cancellationToken)
    {
        await deleteCustomerRepository.DeleteCustomerAsync(command.CustomerId, cancellationToken);
    }
}
