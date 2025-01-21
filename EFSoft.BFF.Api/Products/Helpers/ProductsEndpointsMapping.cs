namespace EFSoft.BFF.Api.Products.Helpers;

public class ProductsEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("product")
            .WithTags(FeatureFlags.Products)
            .AddEndpointFilter(new FeatureFlagEndpointFilter(FeatureFlags.Products));
        //.RequireAuthorization();

        _ = group.MapGet("/{productId:guid}", GetProductEndpoint.GetProduct)
            .MapToApiVersion(1);

        _ = group.MapPost("/get-products", GetProductsEndpoint.GetProducts)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<GetProductsRequest>>();

        _ = group.MapPost("/", CreateProductEndpoint.CreateProduct)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<CreateProductRequest>>();

        _ = group.MapPut("/", UpdateProductEndpoint.UpdateProduct)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<UpdateProductRequest>>();

        _ = group.MapDelete("/{productId:guid}", DeleteProductEndpoint.DeleteProduct)
            .MapToApiVersion(1);
    }
}
