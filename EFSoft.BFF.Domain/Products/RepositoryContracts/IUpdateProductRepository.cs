namespace EFSoft.Bff.Domain.Products.RepositoryContracts;

public interface IUpdateProductRepository
{
    Task UpdateProductAsync(
        ProductDomainModel product,
        CancellationToken cancellationToken = default);
}
