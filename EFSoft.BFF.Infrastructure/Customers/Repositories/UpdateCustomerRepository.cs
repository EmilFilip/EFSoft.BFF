namespace EFSoft.BFF.Infrastructure.Customers.Repositories;

public class UpdateCustomerRepository : IUpdateCustomerRepository
{
    public Task UpdateCustomerAsync(CustomerDomainModel customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
