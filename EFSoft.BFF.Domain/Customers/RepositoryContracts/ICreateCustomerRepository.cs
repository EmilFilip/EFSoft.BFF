namespace EFSoft.BFF.Domain.Customers.RepositoryContracts;

public interface ICreateCustomerRepository
{
    Task CreateCustomerAsync(
        CustomerDomainModel customer,
        CancellationToken cancellationToken = default);
}
