namespace EFSoft.BFF.Infrastructure.Inventory.Repositories;

public class CreateProductInventoryRepository : ICreateProductInventoryRepository
{
    public Task CreateProductInventoryAsync(ProductInventoryModel inventory, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
