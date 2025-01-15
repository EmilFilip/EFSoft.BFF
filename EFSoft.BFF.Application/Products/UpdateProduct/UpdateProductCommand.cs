namespace EFSoft.Bff.Application.Products.UpdateProduct;

public sealed record UpdateProductCommand(
         Guid ProductId,
         string Description,
         bool InStock) : ICommand;
