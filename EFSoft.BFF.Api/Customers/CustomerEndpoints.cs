using EFSoft.BFF.Api.Helpers;

namespace EFSoft.BFF.Api.CustomerEndpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/customer");//.RequireAuthorization();

        group.MapGet("{customerId:guid}", Get);
        group.MapGet("{customerIds}", GetCustomers);
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
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var getCustomerEndpoint = configuration["CustomersService:GetCustomerEndpoint"] ?? throw new ConfigNotFoundException("GetCustomerEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            Content = HttpClientHelpers.GetStringContent(customerId),
            RequestUri = new Uri($"{httpClient.BaseAddress}{getCustomerEndpoint}{customerId}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage, cancellationToken);

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

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            Content = HttpClientHelpers.GetStringContent(customerIds),
            RequestUri = new Uri($"{httpClient.BaseAddress}/{getCustomersEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

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
        var postCustomersEndpoint = configuration["CustomersService:PostCustomersEndpoint"] ?? throw new ConfigNotFoundException("PostCustomersEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}/{postCustomersEndpoint}")
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
        var putCustomersEndpoint = configuration["CustomersService:PutCustomersEndpoint"] ?? throw new ConfigNotFoundException("PutCustomersEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}/{putCustomersEndpoint}")
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
        var deleteCustomersEndpoint = configuration["CustomersService:DeleteCustomersEndpoint"] ?? throw new ConfigNotFoundException("DeleteCustomersEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            Content = HttpClientHelpers.GetStringContent(customerId),
            RequestUri = new Uri($"{httpClient.BaseAddress}/{deleteCustomersEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }
}
