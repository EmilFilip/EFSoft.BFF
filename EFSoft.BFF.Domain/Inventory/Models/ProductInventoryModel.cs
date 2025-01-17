namespace EFSoft.BFF.Domain.Inventory.Models;

public class ProductInventoryModel
{
    [JsonPropertyName("productId")]
    public Guid ProductId { get; set; }

    [JsonPropertyName("stockLeft")]
    public int StockLeft { get; set; }
}
