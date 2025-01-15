namespace EFSoft.BFF.Api.Inventory.CreateInventory;

public sealed record CreateInventoryRequest(
         Guid ProductId,
         int StockLeft);
