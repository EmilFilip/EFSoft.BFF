namespace EFSoft.BFF.Application.Orders.GetCustomerOrders;

public class GetCustomerOrdersQueryHandler(IHttpClientFactory httpClientFactory) : IQueryHandler<GetCustomerOrdersQuery, GetCustomerOrdersQueryResult>
{
    public async Task<GetCustomerOrdersQueryResult> Handle(
            GetCustomerOrdersQuery command,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.OrdersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.GetCustomerOrdersEndpoint.Replace("{customerId}", command.CustomerId.ToString())}");

        var content = HttpClientHelpers.GetStringContent(command);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var getCustomerOrdersHttpResponse = await response.Content.ReadAsAsync<GetCustomerOrdersHttpResponse>();

        return new GetCustomerOrdersQueryResult(getCustomerOrdersHttpResponse.Orders);
    }
}
