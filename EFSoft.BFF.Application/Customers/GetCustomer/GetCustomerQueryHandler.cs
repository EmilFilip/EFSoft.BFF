namespace EFSoft.BFF.Application.Customers.GetCustomer;

public class GetCustomerQueryHandler(IHttpClientFactory httpClientFactory)
    : IQueryHandler<GetCustomerQuery, GetCustomerQueryResult?>
{
    public async Task<GetCustomerQueryResult?> Handle(
            GetCustomerQuery query,
            CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClient.CustomersServiceHttpCientName);

        var requestUri = new Uri($"{httpClient.BaseAddress}" +
            $"{Constants.HttpClient.ApiRoutes.GetCustomerEndpoint.Replace("{customerId}", query.CustomerId.ToString())}");

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        _ = response.EnsureSuccessStatusCode();

        var customer = await response.Content.ReadAsAsync<CustomerModel>();

        if (customer is null)
        {
            return default;
        }

        return new GetCustomerQueryResult(
            CustomerId: customer.CustomerId,
            FullName: customer.FullName,
            DateOfBirth: customer.DateOfBirth,
            HasOpenedOrder: customer.HasOpenOrder);
    }
}
