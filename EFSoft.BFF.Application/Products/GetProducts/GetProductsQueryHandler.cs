namespace EFSoft.Bff.Application.Products.GetProducts;

public class GetProductsQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetProductsQuery, GetProductsQueryResult>
{
    public async Task<GetProductsQueryResult> Handle(
            GetProductsQuery query,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.ProductsServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.GetProductsEndpoint}");

        var content = HttpClientHelpers.GetStringContent(query);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var getProductsHttpResponse = await response.Content.ReadAsAsync<GetProductsHttpResponse>();

        return new GetProductsQueryResult(getProductsHttpResponse.Products);
    }
}
