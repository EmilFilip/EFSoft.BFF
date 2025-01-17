namespace EFSoft.BFF.Application.Customers.GetCustomers;

public class GetCustomersQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetCustomersQuery, GetCustomersQueryResult>
{
    public async Task<GetCustomersQueryResult> Handle(
            GetCustomersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.GetCustomersEndpoint}");

        var content = HttpClientHelpers.GetStringContent(parameters);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var getCustomersHttpResponse = await response.Content.ReadAsAsync<GetCustomersHttpResponse>();

        return new GetCustomersQueryResult(getCustomersHttpResponse.Customers);
    }
}
