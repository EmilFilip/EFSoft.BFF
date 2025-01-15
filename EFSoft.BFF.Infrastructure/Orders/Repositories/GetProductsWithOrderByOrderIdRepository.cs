namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class GetProductsWithOrderByOrderIdRepository : IGetProductsWithOrderByOrderIdRepository
{
    public Task<IEnumerable<OrderProductDomainModel>> GetProductsWithOrderByOrderIdAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
