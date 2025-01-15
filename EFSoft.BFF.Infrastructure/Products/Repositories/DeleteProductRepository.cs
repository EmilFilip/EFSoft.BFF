namespace EFSoft.BFF.Infrastructure.Products.Repositories;

public class DeleteProductRepository : IDeleteProductRepository
{
    public Task DeleteProductAsync(Guid productId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
