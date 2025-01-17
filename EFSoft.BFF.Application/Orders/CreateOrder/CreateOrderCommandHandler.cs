namespace EFSoft.BFF.Application.Orders.CreateOrder;

public class CreateOrderCommandHandler(IHttpClientFactory httpClientFactory) : ICommandHandler<CreateOrderCommand>
{
    public async Task Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.OrdersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.CreateOrderEndpoint}");

        var content = HttpClientHelpers.GetStringContent(command);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();
    }
}
