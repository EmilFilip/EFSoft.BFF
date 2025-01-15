//using EFSoft.BFF.Api.Inventory.Commands;
//using EFSoft.BFF.Api.Inventory.Queries.GetInventory;

//namespace EFSoft.BFF.Api.Inventory;

//public static class InventoryEndpoints
//{
//    public static void MapInventoryEndpoints(this IEndpointRouteBuilder endpoint)
//    {
//        var group = endpoint.MapGroup("api/inventory").RequireAuthorization();

//        group.MapGet("{productId:guid}", Get);
//        group.MapPost("", Post);
//        group.MapPut("", Put);
//    }

//    public static async Task<Results<Ok<GetInventoryQueryResult>, NotFound>> Get(
//        Guid productId,
//        IHttpClientFactory httpClientFactory,
//        IConfiguration configuration,
//        CancellationToken cancellationToken)
//    {
//        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.InventoryServiceHttpCientName);
//        var getInventoryEndpoint = configuration["InventoryService:GetInventoryEndpoint"] ?? throw new ConfigNotFoundException("GetInventoryEndpoint is null");

//        var requestUri = new Uri($"{httpClient.BaseAddress}{getInventoryEndpoint}{productId}");

//        var requestMessage = new HttpRequestMessage
//        {
//            Method = HttpMethod.Get,
//            RequestUri = requestUri
//        };

//        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

//        response.EnsureSuccessStatusCode();
//        var results = await response.Content.ReadFromJsonAsync<GetInventoryQueryResult>();

//        if (results == null)
//        {
//            return TypedResults.NotFound();
//        }

//        return TypedResults.Ok(results);
//    }

//    public static async Task<IResult> Post(
//        [FromBody] CreateInventoryCommand parameters,
//        IHttpClientFactory httpClientFactory,
//        IConfiguration configuration,
//        CancellationToken cancellationToken)
//    {
//        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.InventoryServiceHttpCientName);
//        var postInventoryEndpoint = configuration["InventoryService:PostInventoryEndpoint"] ?? throw new ConfigNotFoundException("PostInventoryEndpoint is either null");

//        var requestMessage = new HttpRequestMessage
//        {
//            Method = HttpMethod.Post,
//            Content = HttpClientHelpers.GetStringContent(parameters),
//            RequestUri = new Uri($"{httpClient.BaseAddress}{postInventoryEndpoint}")
//        };

//        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
//        response.EnsureSuccessStatusCode();

//        return Results.Ok();
//    }

//    public static async Task<IResult> Put(
//        [FromBody] UpdateInventoryCommand parameters,
//        IHttpClientFactory httpClientFactory,
//        IConfiguration configuration,
//        CancellationToken cancellationToken)
//    {
//        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.InventoryServiceHttpCientName);
//        var putInventoryEndpoint = configuration["InventoryService:PutInventoryEndpoint"] ?? throw new ConfigNotFoundException("PutInventoryEndpoint is either null");

//        var requestMessage = new HttpRequestMessage
//        {
//            Method = HttpMethod.Put,
//            Content = HttpClientHelpers.GetStringContent(parameters),
//            RequestUri = new Uri($"{httpClient.BaseAddress}{putInventoryEndpoint}")
//        };

//        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
//        response.EnsureSuccessStatusCode();

//        return Results.Ok();
//    }
//}
