namespace EFSoft.Bff.Domain.Products.RepositoryContracts;

public interface IGetProductsRepository
{
    Task<IEnumerable<ProductDomainModel>> GetProductsAsync(
          IEnumerable<Guid> productIds,
          CancellationToken cancellationToken = default);
}
