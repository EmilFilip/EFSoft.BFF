namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class GetOrderRepository : IGetOrderRepository
{
    public Task<OrderDomainModel> GetOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
