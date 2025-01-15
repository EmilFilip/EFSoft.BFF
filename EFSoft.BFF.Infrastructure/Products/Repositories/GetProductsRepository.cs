namespace EFSoft.BFF.Infrastructure.Products.Repositories;

public class GetProductsRepository : IGetProductsRepository
{
    public Task<IEnumerable<ProductDomainModel>> GetProductsAsync(IEnumerable<Guid> productIds, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
