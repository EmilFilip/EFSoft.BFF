﻿namespace EFSoft.BFF.Api.MicroServices.Inventory.Queries.GetInventory;

public class GetInventoryQueryResult 
{
    public GetInventoryQueryResult(
        Guid productId,
        int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public Guid ProductId { get; set; }

    public int StockLeft { get; set; }
}