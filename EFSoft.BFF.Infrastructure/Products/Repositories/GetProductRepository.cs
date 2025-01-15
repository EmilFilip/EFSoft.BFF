namespace EFSoft.BFF.Infrastructure.Products.Repositories;

public class GetProductRepository : IGetProductRepository
{
    public Task<ProductDomainModel?> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
