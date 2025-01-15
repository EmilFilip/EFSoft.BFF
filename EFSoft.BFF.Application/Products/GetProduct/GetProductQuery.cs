namespace EFSoft.Bff.Application.Products.GetProduct;

public sealed record GetProductQuery(Guid ProductId) : IQuery<GetProductQueryResult>;
