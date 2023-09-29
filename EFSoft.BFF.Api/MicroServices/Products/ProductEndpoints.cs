namespace EFSoft.BFF.Api.MicroServices.Products;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("api/product");//.RequireAuthorization();

        group.MapGet("{productId:guid}", Get);
        group.MapGet("", GetProducts);
        group.MapPost("", Post);
        group.MapPut("", Put);
        group.MapDelete("{productId:guid}", Delete);
    }

    public static async Task<Results<Ok<GetProductQueryResult>, NotFound>> Get(
        Guid productId,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.ProductsServiceHttpCientName);
        var getProductEndpoint = configuration["ProductsService:GetProductEndpoint"] ?? throw new ConfigNotFoundException("GetProductEndpoint is null");

        var requestUri = new Uri($"{httpClient.BaseAddress}{getProductEndpoint}{productId}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();
        var results = await response.Content.ReadFromJsonAsync<GetProductQueryResult>();

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<GetProductsQueryResult>, NotFound>> GetProducts(
        Guid[] productIds,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.ProductsServiceHttpCientName);
        var getProductsEndpoint = configuration["ProductsService:GetProductsEndpoint"] ?? throw new ConfigNotFoundException("GetProductsEndpoint is null");

        var productIdsUri = new StringBuilder();

        foreach (var productId in productIds)
        {
            productIdsUri.Append($"&productIds={productId}");
        }

        var requestUri = new Uri($"{httpClient.BaseAddress}{getProductsEndpoint}?{productIdsUri}");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = requestUri
        };

        var response = await httpClient.SendAsync(requestMessage, cancellationToken);

        response.EnsureSuccessStatusCode();
        var results = await response.Content.ReadFromJsonAsync<GetProductsQueryResult>();

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<IResult> Post(
        [FromBody] CreateProductCommand parameters,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var postProductEndpoint = configuration["ProductsService:PostProductEndpoint"] ?? throw new ConfigNotFoundException("PostProductEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}{postProductEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }

    public static async Task<IResult> Put(
        [FromBody] UpdateProductCommand parameters,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var putProductEndpoint = configuration["ProductsService:PutProductEndpoint"] ?? throw new ConfigNotFoundException("PutProductEndpoint is either null");

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            Content = HttpClientHelpers.GetStringContent(parameters),
            RequestUri = new Uri($"{httpClient.BaseAddress}{putProductEndpoint}")
        };

        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        return Results.Ok();
    }

    public static async Task<IResult> Delete(
        Guid productId,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient(Constants.HttpClientConstants.CustomersServiceHttpCientName);
        var deleteProductEndpoint = configuration["ProductsService:DeleteProductEndpoint"] ?? throw new ConfigNotFoundException("DeleteProductEndpoint key wasn't found");

        var requestUri = new Uri($"{httpClient.BaseAddress}{deleteProductEndpoint}{productId}");

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
