namespace EFSoft.BFF.Api.MicroServices.Inventory.Commands;

public sealed record class CreateInventoryCommand(
         Guid ProductId,
         int StockLeft);
