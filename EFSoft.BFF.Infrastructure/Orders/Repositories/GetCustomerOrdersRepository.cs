namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class GetCustomerOrdersRepository : IGetCustomerOrdersRepository
{
    public Task<IEnumerable<OrderDomainModel>> GetCustomerOrdersAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
