namespace EFSoft.BFF.Domain.Inventory.RepositoryContracts;

public interface IGetProductInventoryRepository
{
    Task<ProductInventoryModel?> GetProductInventoryAsync(
        Guid productInventory,
        CancellationToken cancellationToken = default);
}
