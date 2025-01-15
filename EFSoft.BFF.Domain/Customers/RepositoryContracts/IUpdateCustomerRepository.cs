namespace EFSoft.BFF.Domain.Customers.RepositoryContracts;
public interface IUpdateCustomerRepository
{
    Task UpdateCustomerAsync(
        CustomerDomainModel customer,
        CancellationToken cancellationToken = default);
}
