namespace EFSoft.BFF.Api.MicroServices.Orders.Commands;

public static class OrderEnpoints
{
    public static void MapOrderEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/order").RequireAuthorization();

        group.MapGet("{orderId:guid}", Get);
        group.MapGet("getCustomerOrders/{customerId:guid}", GetCustomerOrders);
        group.MapPost("", Post);
        group.MapPut("", Put);
    }

    public static async Task<Results<Ok<GetOrderQueryResult>, NotFound>> Get(
        Guid orderId,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.OrdersServiceHttpCientName);
        var getCustomerEndpoint = configuration["OrdersService:GetOrderEndpoint"] ?? throw new ConfigNotFoundException("GetOrderEndpoint is null");

        var requestUri = new Uri($"{httpClient.BaseAddress}{getCustomerEndpoint}{orderId}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();
        var results = await response.Content.ReadFromJsonAsync<GetOrderQueryResult>();

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
    public static async Task<Results<Ok<GetCustomerOrdersQueryResult>, NotFound>> GetCustomerOrders(
        Guid customerId,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.OrdersServiceHttpCientName);
        var getCustomerEndpoint = configuration["OrdersService:GetCustomerOrdersEndpoint"] ?? throw new ConfigNotFoundException("GetCustomerOrdersEndpoint is null");

        var requestUri = new Uri($"{httpClient.BaseAddress}{getCustomerEndpoint}{customerId}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();
        var results = await response.Content.ReadFromJsonAsync<GetCustomerOrdersQueryResult>();

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateOrderCommand parameters,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.OrdersServiceHttpCientName);
        var postCustomersEndpoint = configuration["OrdersService:PostOrderEndpoint"] ?? throw new ConfigNotFoundException("PostOrderEndpoint is either null");

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
        [FromBody] UpdateOrderCommand parameters,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.OrdersServiceHttpCientName);
        var postCustomersEndpoint = configuration["OrdersService:PutOrderEndpoint"] ?? throw new ConfigNotFoundException("PutOrderEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}{postCustomersEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }
}
