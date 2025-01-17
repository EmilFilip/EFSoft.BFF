namespace EFSoft.BFF.Application.Customers.UpdateCustomer;

public class UpdateCustomerCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<UpdateCustomerCommand>
{
    public async Task Handle(
        UpdateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.UpdateCustomerEndpoint}");

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
