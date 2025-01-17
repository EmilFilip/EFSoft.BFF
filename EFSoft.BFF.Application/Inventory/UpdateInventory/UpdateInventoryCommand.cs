namespace EFSoft.BFF.Application.Inventory.UpdateInventory;

public sealed record UpdateInventoryCommand(
         Guid ProductId,
         int StockLeft) : ICommand;
