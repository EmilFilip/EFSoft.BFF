namespace EFSoft.BFF.Application.Products.GetProducts;

public class GetProductsHttpResponse
{
    [JsonPropertyName("products")]
    public IEnumerable<ProductModel>? Products { get; set; }
}
