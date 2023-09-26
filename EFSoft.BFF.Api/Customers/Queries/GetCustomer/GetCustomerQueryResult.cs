namespace EFSoft.BFF.Api.Customers.GetCustomer;

public class GetCustomerQueryResult
{
    public GetCustomerQueryResult(
        string fullName,
        DateTimeOffset dateOfBirth)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public string FullName { get; }
    public DateTimeOffset DateOfBirth { get; }
}
