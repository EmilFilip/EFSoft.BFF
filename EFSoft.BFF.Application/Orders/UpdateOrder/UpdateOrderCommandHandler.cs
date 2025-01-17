namespace EFSoft.BFF.Application.Orders.UpdateOrder;

public class UpdateOrderCommandHandler(IHttpClientFactory httpClientFactory) : ICommandHandler<UpdateOrderCommand>
{
    public async Task Handle(
        UpdateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.OrdersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.UpdateOrderEndpoint}");

        var content = HttpClientHelpers.GetStringContent(command);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();
    }
}
