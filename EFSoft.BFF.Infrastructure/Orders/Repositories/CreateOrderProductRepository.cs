namespace EFSoft.BFF.Infrastructure.Orders.Repositories;

public class CreateOrderProductRepository : ICreateOrderProductRepository
{
    public Task CreateOrderProductAsync(IEnumerable<OrderProductDomainModel> order, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
