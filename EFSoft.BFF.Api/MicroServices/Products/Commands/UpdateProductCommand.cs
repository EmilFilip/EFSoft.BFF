namespace EFSoft.BFF.Api.MicroServices.Products.Commands;

public sealed record class UpdateProductCommand(
         Guid ProductId,
         string Description,
         bool InStock);