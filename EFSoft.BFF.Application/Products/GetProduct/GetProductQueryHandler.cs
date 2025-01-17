namespace EFSoft.Bff.Application.Products.GetProduct;

public class GetProductQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetProductQuery, GetProductQueryResult?>
{
    public async Task<GetProductQueryResult?> Handle(
            GetProductQuery query,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.ProductsServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}" +
            $"{Constants.HttpClient.ApiRoutes.GetProductEndpoint.Replace("{productId}", query.ProductId.ToString())}");

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var product = await response.Content.ReadAsAsync<ProductModel>();

        if (product is null)
        {
            return default;
        }

        return new GetProductQueryResult(
            ProductId: product.ProductId,
            Description: product.Description,
            InStock: product.InStock);
    }
}
