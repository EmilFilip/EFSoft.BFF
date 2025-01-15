namespace EFSoft.Bff.Domain.Products.RepositoryContracts;

public interface IDeleteProductRepository
{
    Task DeleteProductAsync(
    Guid productId,
    CancellationToken cancellationToken = default);
}
