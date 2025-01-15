namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class GetOrderProductsForOrderRepository : IGetOrderProductsForOrderRepository
{
    public Task<IEnumerable<OrderProductDomainModel>> GetOrderProductsForOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
