namespace EFSoft.BFF.Api.MicroServices.Customers.Models;

public class CustomerModel
{
    public CustomerModel(
        Guid customerId,
        string fullName,
        DateTimeOffset dateOfBirth,
        bool hasOpenOrder)
    {
        CustomerId = customerId;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        HasOpenOrder = hasOpenOrder;
    }

    public Guid CustomerId { get; }

    public string FullName { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public bool HasOpenOrder { get; set; }
}
