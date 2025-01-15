namespace EFSoft.BFF.Api.Customers.CreateCustomer;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        _ = RuleFor(e => e.FullName)
            .NotNull().WithMessage("FullName cannot be null")
            .NotEmpty().WithMessage("FullName cannot be empty");
    }
}
