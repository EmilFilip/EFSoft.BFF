namespace EFSoft.BFF.Application.Orders.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler(IHttpClientFactory httpClientFactory) : ICommandHandler<UpdateOrderStatusCommand>
{
    public async Task Handle(
        UpdateOrderStatusCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.OrdersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.UpdateOrderStatusEndpoint}");

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
