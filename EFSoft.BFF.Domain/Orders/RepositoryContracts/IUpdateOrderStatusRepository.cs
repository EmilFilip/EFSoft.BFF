namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IUpdateOrderStatusRepository
{
    Task UpdateOrderStatusAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default);
}
