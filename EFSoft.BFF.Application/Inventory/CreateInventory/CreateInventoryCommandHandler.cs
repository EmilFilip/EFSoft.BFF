namespace EFSoft.BFF.Application.Inventory.CreateInventory;

public class CreateInventoryCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<CreateInventoryCommand>
{
    public async Task Handle(
        CreateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.InventoryServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.CreateInventoryEndpoint}");

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
