namespace EFSoft.BFF.Api.CustomerEndpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/customer").RequireAuthorization();

        group.MapGet("{customerId:guid}", Get);
        group.MapGet("", GetCustomers);
        group.MapPost("", Post);
        group.MapPut("", Put);
        group.MapDelete("{customerId:guid}", Delete);
    }

    public static async Task<Results<Ok<GetCustomerQueryResult>, NotFound>> Get(
        Guid customerId,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var getCustomerEndpoint = configuration["CustomersService:GetCustomerEndpoint"] ?? throw new ConfigNotFoundException("GetCustomerEndpoint is either null");

        var requestUri = new Uri($"{httpClient.BaseAddress}{getCustomerEndpoint}{customerId}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();
        var results = await response.Content.ReadFromJsonAsync<GetCustomerQueryResult>();

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<IEnumerable<CustomerModel>>, NotFound>> GetCustomers(
        Guid[] customerIds,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var getCustomersEndpoint = configuration["CustomersService:GetCustomersEndpoint"] ?? throw new ConfigNotFoundException("GetCustomersEndpoint is either null");

        var customerIdsUri = new StringBuilder();

        foreach (var customerId in customerIds)
        {
            customerIdsUri.Append($"&customerIds={customerId}");
        }

        var requestUri = new Uri($"{httpClient.BaseAddress}{getCustomersEndpoint}?{customerIdsUri}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

        var results = await response.Content.ReadFromJsonAsync<GetCustomersQueryResult>();
        response.EnsureSuccessStatusCode();

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results.Customers);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateCustomerCommand parameters,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var postCustomersEndpoint = configuration["CustomersService:PostCustomerEndpoint"] ?? throw new ConfigNotFoundException("PostCustomerEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}{postCustomersEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateCustomerCommand parameters,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var putCustomersEndpoint = configuration["CustomersService:PutCustomerEndpoint"] ?? throw new ConfigNotFoundException("PutCustomerEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}{putCustomersEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }

    public static async Task<IResult> Delete(
        Guid customerId,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var deleteCustomersEndpoint = configuration["CustomersService:DeleteCustomerEndpoint"] ?? throw new ConfigNotFoundException("DeleteCustomerEndpoint key wasn't found");

        var requestUri = new Uri($"{httpClient.BaseAddress}{deleteCustomersEndpoint}{customerId}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }
}
