namespace EFSoft.BFF.Infrastructure.Customers.Repositories;

public class GetAllCustomersRepository : IGetAllCustomersRepository
{
    public Task<PagedList<CustomerDomainModel>> GetAllCustomersAsync(PagedListParams pagedListParams, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
