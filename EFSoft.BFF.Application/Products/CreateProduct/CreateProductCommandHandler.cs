namespace EFSoft.Bff.Application.Products.CreateProduct;

public class CreateProductCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<CreateProductCommand>
{
    public async Task Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.ProductsServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.CreateProductEndpoint}");

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
