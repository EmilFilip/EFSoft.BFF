namespace EFSoft.BFF.Application.Inventory.CreateInventory;

public sealed record CreateInventoryCommand(
         Guid ProductId,
         int StockLeft) : ICommand;
