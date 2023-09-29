namespace EFSoft.BFF.Api.MicroServices.Products.Queries.GetProducts;

public sealed record GetProductsQuery(IEnumerable<Guid> ProductIds);