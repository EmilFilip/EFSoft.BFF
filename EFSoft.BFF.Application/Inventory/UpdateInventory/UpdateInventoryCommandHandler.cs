namespace EFSoft.BFF.Application.Inventory.UpdateInventory;

public class UpdateInventoryCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<UpdateInventoryCommand>
{
    public async Task Handle(
        UpdateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.InventoryServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.UpdateInventoryEndpoint}");

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
