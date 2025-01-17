namespace EFSoft.Bff.Application.Products.GetProducts;

public class GetProductsQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetProductsQuery, GetProductsQueryResult>
{
    public async Task<GetProductsQueryResult> Handle(
            GetProductsQuery parameters,
            CancellationToken cancellationToken = default)
    {
        //var products = await getProductsRepository.GetProductsAsync(
        //    productIds: parameters.ProductIds,
        //    cancellationToken: cancellationToken);

        return default; // new GetProductsQueryResult(products);
    }
}
