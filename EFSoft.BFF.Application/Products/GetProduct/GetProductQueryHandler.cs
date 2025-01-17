namespace EFSoft.Bff.Application.Products.GetProduct;

public class GetProductQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetProductQuery, GetProductQueryResult?>
{
    public async Task<GetProductQueryResult?> Handle(
            GetProductQuery query,
            CancellationToken cancellationToken = default)
    {
        //var product = await getProductRepository.GetProductAsync(
        //    parameters.ProductId,
        //    cancellationToken);


        //if (product is null)
        //{
            return default;
        //}


        //return new GetProductQueryResult(
        //    Description: product.Description,
        //    InStock: product.InStock);
    }
}
