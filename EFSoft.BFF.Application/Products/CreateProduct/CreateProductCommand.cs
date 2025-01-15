namespace EFSoft.Bff.Application.Products.CreateProduct;

public sealed record CreateProductCommand(
         string Description,
         bool InStock) : ICommand;
