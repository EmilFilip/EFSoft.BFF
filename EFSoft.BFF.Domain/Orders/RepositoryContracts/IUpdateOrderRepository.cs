namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IUpdateOrderRepository
{
    Task UpdateOrderAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default);
}
