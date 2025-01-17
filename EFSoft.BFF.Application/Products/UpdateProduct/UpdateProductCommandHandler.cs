namespace EFSoft.Bff.Application.Products.UpdateProduct;

public class UpdateProductCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task Handle(
        UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.ProductsServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.UpdateProductEndpoint}");

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
