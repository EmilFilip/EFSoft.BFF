namespace EFSoft.BFF.Application.Orders.GetOrder;

public class GetOrderQueryHandler(IHttpClientFactory httpClientFactory) : IQueryHandler<GetOrderQuery, GetOrderQueryResult?>
{
    public async Task<GetOrderQueryResult?> Handle(
            GetOrderQuery query,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.OrdersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.GetOrderEndpoint.Replace("{orderId}", query.OrderId.ToString())}");

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var getOrderHttpResponse = await response.Content.ReadAsAsync<GetOrderHttpResponse>();

        return new GetOrderQueryResult(getOrderHttpResponse.Order);
    }
}
