namespace EFSoft.BFF.Api.MicroServices.Inventory.Commands;

public sealed record class UpdateInventoryCommand(
         Guid ProductId,
         int StockLeft);
