namespace EFSoft.BFF.Application.Customers.CreateCustomer;

public class CreateCustomerCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task Handle(
        CreateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.CreateCustomerEndpoint}");

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
