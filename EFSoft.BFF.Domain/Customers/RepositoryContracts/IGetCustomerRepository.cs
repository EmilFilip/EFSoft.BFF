namespace EFSoft.BFF.Domain.Customers.RepositoryContracts;

public interface IGetCustomerRepository
{
    Task<CustomerDomainModel?> GetCustomerAsync(
              Guid customerId,
              CancellationToken cancellationToken = default);
}
