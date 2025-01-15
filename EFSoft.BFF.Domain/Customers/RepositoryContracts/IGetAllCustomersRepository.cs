namespace EFSoft.BFF.Domain.Customers.RepositoryContracts;

public interface IGetAllCustomersRepository
{
    Task<PagedList<CustomerDomainModel>> GetAllCustomersAsync(
          PagedListParams pagedListParams,
          CancellationToken cancellationToken = default);
}
