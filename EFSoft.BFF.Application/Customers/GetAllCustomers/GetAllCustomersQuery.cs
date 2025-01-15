﻿namespace EFSoft.BFF.Application.Customers.GetAllCustomers;

public sealed record GetAllCustomersQuery(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize) : IQuery<GetAllCustomersQueryResult>;
