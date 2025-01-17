namespace EFSoft.BFF.Application.Customers.GetAllCustomers;

public class GetAllCustomersQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetAllCustomersQuery, GetAllCustomersQueryResult>
{
    public async Task<GetAllCustomersQueryResult> Handle(
            GetAllCustomersQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}{Constants.HttpClient.ApiRoutes.GetAllCustomersEndpoint}");

        var content = HttpClientHelpers.GetStringContent(parameters);

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = requestUri,
            Content = content
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var contentDeserialized = await response.Content.ReadAsAsync<GetCustomersHttpResponse>();

        return new GetAllCustomersQueryResult(contentDeserialized.PagedList);
    }
}
