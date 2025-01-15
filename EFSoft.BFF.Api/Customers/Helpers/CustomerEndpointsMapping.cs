﻿namespace EFSoft.BFF.Api.Customers.Helpers;

public class CustomerEndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/customer").WithTags("Customers");

        _ = group.MapGet("/{customerId:guid}", GetCustomerEndpoint.GetCustomer);

        _ = group.MapPost("/get-customers", GetCustomersEndpoint.GetCustomers)
            .AddEndpointFilter<ValidationFilter<GetCustomersRequest>>();

        _ = group.MapPost("/get-all-customers", GetAllCustomersEndpoint.GetAllCustomers)
            .AddEndpointFilter<ValidationFilter<GetAllCustomersRequest>>();

        _ = group.MapPost("/", CreateCustomerEndpoint.CreateCustomer)
            .AddEndpointFilter<ValidationFilter<CreateCustomerRequest>>();

        _ = group.MapPut("/", UpdateCustomerEndpoint.UpdateCustomer)
            .AddEndpointFilter<ValidationFilter<UpdateCustomerRequest>>();

        _ = group.MapDelete("/{customerId:guid}", DeleteCustomerEndpoint.DeleteCustomer);
    }
}
