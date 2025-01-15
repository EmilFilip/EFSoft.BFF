namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IGetOrderProductsForOrderRepository
{
    Task<IEnumerable<OrderProductDomainModel>> GetOrderProductsForOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default);
}
