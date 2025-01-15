namespace EFSoft.BFF.Infrastructure.Customers.Repositories;

public class DeleteCustomerRepository : IDeleteCustomerRepository
{
    public Task DeleteCustomerAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
