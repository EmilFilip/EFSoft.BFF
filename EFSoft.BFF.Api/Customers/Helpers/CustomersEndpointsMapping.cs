namespace EFSoft.BFF.Api.Customers.Helpers;

public class CustomersEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("customer")
            .WithTags(FeatureFlags.Customers)
            .AddEndpointFilter(new FeatureFlagEndpointFilter(FeatureFlags.Customers));
        //.RequireAuthorization();

        _ = group.MapGet("/{customerId:guid}", GetCustomerEndpoint.GetCustomer)
            .MapToApiVersion(1);

        _ = group.MapPost("/get-customers", GetCustomersEndpoint.GetCustomers)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<GetCustomersRequest>>();

        _ = group.MapPost("/get-customers", GetCustomersEndpoint.GetCustomersV2)
            .MapToApiVersion(2)
            .AddEndpointFilter<ValidationFilter<GetCustomersRequest>>();

        _ = group.MapPost("/get-all-customers", GetAllCustomersEndpoint.GetAllCustomers)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<GetAllCustomersRequest>>();

        _ = group.MapPost("/", CreateCustomerEndpoint.CreateCustomer)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<CreateCustomerRequest>>();

        _ = group.MapPut("/", UpdateCustomerEndpoint.UpdateCustomer)
            .MapToApiVersion(1)
            .AddEndpointFilter<ValidationFilter<UpdateCustomerRequest>>();

        _ = group.MapDelete("/{customerId:guid}", DeleteCustomerEndpoint.DeleteCustomer)
            .MapToApiVersion(1);
    }
}
