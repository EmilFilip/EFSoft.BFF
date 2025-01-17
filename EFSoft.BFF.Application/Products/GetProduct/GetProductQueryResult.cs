namespace EFSoft.Bff.Application.Products.GetProduct;

public sealed record GetProductQueryResult(
        Guid ProductId,
        string Description,
        bool InStock);
