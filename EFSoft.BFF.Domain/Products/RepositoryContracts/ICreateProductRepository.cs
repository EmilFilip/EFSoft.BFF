namespace EFSoft.Bff.Domain.Products.RepositoryContracts;

public interface ICreateProductRepository
{
    Task CreateProductAsync(
        ProductDomainModel product,
        CancellationToken cancellationToken = default);
}
