namespace EFSoft.Bff.Application.Products.CreateProduct;

public class CreateProductCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<CreateProductCommand>
{
    public async Task Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        //var productModel = ProductDomainModel.CreateNew(
        //    description: command.Description,
        //    inStock: command.InStock);

        //await createProductRepository.CreateProductAsync(
        //    productModel,
        //    cancellationToken);
    }
}
