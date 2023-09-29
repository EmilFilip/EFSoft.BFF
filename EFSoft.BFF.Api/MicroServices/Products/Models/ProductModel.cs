namespace EFSoft.BFF.Api.MicroServices.Products.Models;

public sealed record ProductModel(
           Guid ProductId,
           string Description,
           bool InStock);
