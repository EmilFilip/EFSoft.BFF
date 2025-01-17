namespace EFSoft.BFF.Application.Customers.DeleteCustomer;

public class DeleteCustomerCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<DeleteCustomerCommand>
{
    public async Task Handle(
        DeleteCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}" +
            $"{Constants.HttpClient.ApiRoutes.DeleteCustomerEndpoint.Replace("{customerId}", command.CustomerId.ToString())}");

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();
    }
}
