namespace EFSoft.Bff.Application.Products.DeleteProduct;

public class DeleteProductCommandHandler(IDeleteProductRepository deleteProductRepository)
    : ICommandHandler<DeleteProductCommand>
{
    public async Task Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        await deleteProductRepository.DeleteProductAsync(
            command.ProductId,
            cancellationToken);
    }
}
