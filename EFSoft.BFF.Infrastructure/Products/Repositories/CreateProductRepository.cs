namespace EFSoft.BFF.Infrastructure.Products.Repositories;

public class CreateProductRepository : ICreateProductRepository
{
    public Task CreateProductAsync(ProductDomainModel product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
