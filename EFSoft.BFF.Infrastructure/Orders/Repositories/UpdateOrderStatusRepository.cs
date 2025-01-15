namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class UpdateOrderStatusRepository : IUpdateOrderStatusRepository
{
    public Task UpdateOrderStatusAsync(OrderDomainModel order, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
