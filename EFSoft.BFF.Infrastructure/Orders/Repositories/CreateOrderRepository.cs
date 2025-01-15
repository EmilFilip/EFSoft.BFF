namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class CreateOrderRepository : ICreateOrderRepository
{
    public Task CreateOrderAsync(OrderDomainModel order, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
