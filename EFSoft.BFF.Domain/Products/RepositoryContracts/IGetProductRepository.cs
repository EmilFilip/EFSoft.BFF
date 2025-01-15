namespace EFSoft.Bff.Domain.Products.RepositoryContracts;

public interface IGetProductRepository
{
    Task<ProductDomainModel?> GetProductAsync(
          Guid productId,
          CancellationToken cancellationToken = default);
}
