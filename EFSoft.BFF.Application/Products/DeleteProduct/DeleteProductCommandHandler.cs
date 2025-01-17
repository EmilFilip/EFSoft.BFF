namespace EFSoft.Bff.Application.Products.DeleteProduct;

public class DeleteProductCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<DeleteProductCommand>
{
    public async Task Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.ProductsServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.DeleteProductEndpoint.Replace("{productId}", command.ProductId.ToString())}");

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();
    }
}
