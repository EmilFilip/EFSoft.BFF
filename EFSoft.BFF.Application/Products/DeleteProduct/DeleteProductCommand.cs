namespace EFSoft.Bff.Application.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand;
