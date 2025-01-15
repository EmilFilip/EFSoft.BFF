namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IGetProductsWithOrderByOrderIdRepository
{
    Task<IEnumerable<OrderProductDomainModel>> GetProductsWithOrderByOrderIdAsync(
        Guid orderId,
        CancellationToken cancellationToken = default);
}
