namespace EFSoft.BFF.Infrastructure.Customers.Repositories;

public class GetCustomerRepository : IGetCustomerRepository
{
    public Task<CustomerDomainModel?> GetCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
