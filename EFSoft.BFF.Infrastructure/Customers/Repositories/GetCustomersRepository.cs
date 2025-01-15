namespace EFSoft.BFF.Infrastructure.Customers.Repositories;

public class GetCustomersRepository : IGetCustomersRepository
{
    public Task<IEnumerable<CustomerDomainModel>> GetCustomersAsync(IEnumerable<Guid> customerIds, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
