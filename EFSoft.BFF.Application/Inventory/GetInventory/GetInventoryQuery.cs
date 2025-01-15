namespace EFSoft.BFF.Application.Inventory.GetInventory;

public sealed record GetInventoryQuery(Guid ProductId) : IQuery<GetInventoryQueryResult>;
