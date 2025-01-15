namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class UpdateOrderProductsRepository : IUpdateOrderProductsRepository
{
    public Task UpdateOrderProductsAsync(IEnumerable<OrderProductDomainModel> orderProducts, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
