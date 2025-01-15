namespace EFSoft.BFF.Api.Customers.GetAllCustomers;

public sealed record GetAllCustomersRequest(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize);
