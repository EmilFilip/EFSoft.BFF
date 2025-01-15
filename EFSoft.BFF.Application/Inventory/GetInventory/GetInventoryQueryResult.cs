namespace EFSoft.BFF.Application.Inventory.GetInventory;

public sealed record GetInventoryQueryResult(
        Guid ProductId,
        int StockLeft);
