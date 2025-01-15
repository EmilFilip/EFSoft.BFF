namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class UpdateOrderRepository : IUpdateOrderRepository
{
    public Task UpdateOrderAsync(OrderDomainModel order, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
