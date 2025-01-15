namespace EFSoft.BFF.Api.Inventory.UpdateInventory;

public sealed record UpdateInventoryRequest(
         Guid ProductId,
         int StockLeft);
