namespace EFSoft.BFF.Infrastructure.Products.Repositories;

public class UpdateProductRepository : IUpdateProductRepository
{
    public Task UpdateProductAsync(ProductDomainModel product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
