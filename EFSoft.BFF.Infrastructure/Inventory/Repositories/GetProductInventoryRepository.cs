namespace EFSoft.BFF.Infrastructure.Inventory.Repositories;

public class GetProductInventoryRepository : IGetProductInventoryRepository
{
    public Task<ProductInventoryModel?> GetProductInventoryAsync(Guid productInventory, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
