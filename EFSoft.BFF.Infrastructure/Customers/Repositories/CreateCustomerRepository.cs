namespace EFSoft.BFF.Infrastructure.Customers.Repositories;

public class CreateCustomerRepository : ICreateCustomerRepository
{
    public Task CreateCustomerAsync(CustomerDomainModel customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
