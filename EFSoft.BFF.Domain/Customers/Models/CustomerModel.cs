namespace EFSoft.BFF.Domain.Customers.Models;

public class CustomerModel
{
    [JsonPropertyName("customerId")]
    public Guid CustomerId { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("hasOpenOrder")]
    public bool HasOpenOrder { get; set; }
}
