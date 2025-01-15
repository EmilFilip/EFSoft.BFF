namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface ICreateOrderRepository
{
    Task CreateOrderAsync(
        OrderDomainModel order,
        CancellationToken cancellationToken = default);

}
