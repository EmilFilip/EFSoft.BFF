namespace EFSoft.BFF.Domain.Customers.RepositoryContracts;

public interface IDeleteCustomerRepository
{
    Task DeleteCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default);
}
