namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IUpdateOrderProductsRepository
{
    Task UpdateOrderProductsAsync(
        IEnumerable<OrderProductDomainModel> orderProducts,
        CancellationToken cancellationToken = default);
}
