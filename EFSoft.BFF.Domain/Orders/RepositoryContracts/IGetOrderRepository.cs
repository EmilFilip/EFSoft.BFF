namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IGetOrderRepository
{
    Task<OrderDomainModel> GetOrderAsync(
             Guid orderId,
             CancellationToken cancellationToken = default);
}
