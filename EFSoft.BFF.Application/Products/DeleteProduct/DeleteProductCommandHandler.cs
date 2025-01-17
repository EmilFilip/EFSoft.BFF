namespace EFSoft.Bff.Application.Products.DeleteProduct;

public class DeleteProductCommandHandler(IHttpClientFactory httpClientFactory)
    : ICommandHandler<DeleteProductCommand>
{
    public async Task Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        //await deleteProductRepository.DeleteProductAsync(
        //    command.ProductId,
        //    cancellationToken);
    }
}
