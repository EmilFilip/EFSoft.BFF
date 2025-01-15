namespace EFSoft.BFF.Domain.Inventory.RepositoryContracts;

public interface ICreateProductInventoryRepository
{
    Task CreateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}
