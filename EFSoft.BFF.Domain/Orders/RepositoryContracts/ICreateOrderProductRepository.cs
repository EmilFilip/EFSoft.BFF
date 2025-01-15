namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface ICreateOrderProductRepository
{
    Task CreateOrderProductAsync(
        IEnumerable<OrderProductDomainModel> order,
        CancellationToken cancellationToken = default);
}
