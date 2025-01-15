namespace EFSoft.BFF.Domain.Inventory.RepositoryContracts;

public interface IUpdateProductInventoryRepository
{
    Task UpdateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}
