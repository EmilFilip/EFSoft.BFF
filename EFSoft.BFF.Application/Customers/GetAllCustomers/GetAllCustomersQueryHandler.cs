namespace EFSoft.BFF.Application.Customers.GetAllCustomers;

public class GetAllCustomersQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetAllCustomersQuery, GetAllCustomersQueryResult>
{
    public async Task<GetAllCustomersQueryResult> Handle(
            GetAllCustomersQuery query,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.GetAllCustomersEndpoint}");

        var content = HttpClientHelpers.GetStringContent(query);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var getAllCustomersHttpResponse = await response.Content.ReadAsAsync<GetAllCustomersHttpResponse>();

        return new GetAllCustomersQueryResult(getAllCustomersHttpResponse.PagedList);
    }
}
