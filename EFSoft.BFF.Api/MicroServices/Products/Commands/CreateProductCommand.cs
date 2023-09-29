namespace EFSoft.BFF.Api.MicroServices.Products.Commands;

public sealed record class CreateProductCommand(
         string Description,
         bool InStock);
