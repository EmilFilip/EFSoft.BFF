namespace EFSoft.BFF.Domain.Customers.RepositoryContracts;

public interface IGetCustomersRepository
{
    Task<IEnumerable<CustomerDomainModel>> GetCustomersAsync(
          IEnumerable<Guid> customerIds,
          CancellationToken cancellationToken = default);
}
