﻿namespace EFSoft.Bff.Application.Products.GetProducts;

public sealed record GetProductsQueryResult(IEnumerable<ProductModel> Products);
