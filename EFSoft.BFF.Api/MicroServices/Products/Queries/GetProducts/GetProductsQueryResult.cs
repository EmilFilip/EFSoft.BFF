namespace EFSoft.BFF.Api.MicroServices.Products.Queries.GetProducts;

public class GetProductsQueryResult
{
    public GetProductsQueryResult(IEnumerable<ProductModel> products)
    {
        Products = products;
    }

    public IEnumerable<ProductModel> Products { get; }
}
