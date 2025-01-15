namespace EFSoft.BFF.Domain.Orders.RepositoryContracts;

public interface IGetCustomerOrdersRepository
{
    Task<IEnumerable<OrderDomainModel>> GetCustomerOrdersAsync(
          Guid customerId,
          CancellationToken cancellationToken = default);
}
