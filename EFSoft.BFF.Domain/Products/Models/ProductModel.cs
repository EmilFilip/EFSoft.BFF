namespace EFSoft.Bff.Domain.Products.Models;

public class ProductModel
{
    [JsonPropertyName("productId")]
    public Guid ProductId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("inStock")]
    public bool InStock { get; set; }
}
