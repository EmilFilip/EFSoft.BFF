namespace EFSoft.BFF.Application.Inventory.GetInventory;

public class GetInventoryQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetInventoryQuery, GetInventoryQueryResult?>
{
    public async Task<GetInventoryQueryResult?> Handle(
            GetInventoryQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.InventoryServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}" +
            $"{Constants.HttpClient.ApiRoutes.GetInventoryEndpoint.Replace("{productId}", parameters.ProductId.ToString())}");

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var inventory = await response.Content.ReadAsAsync<ProductInventoryModel>();

        if (inventory is null)
        {
            return default;
        }

        return new GetInventoryQueryResult(
            ProductId: inventory.ProductId,
            StockLeft: inventory.StockLeft);
    }
}
