namespace EFSoft.Bff.Application.Products.GetProducts;

public sealed record GetProductsQuery(IEnumerable<Guid> ProductIds) : IQuery<GetProductsQueryResult>;
