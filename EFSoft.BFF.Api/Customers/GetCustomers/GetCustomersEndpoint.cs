﻿namespace EFSoft.BFF.Api.Customers.GetCustomers;

public static class GetCustomersEndpoint
{
    public static async Task<Results<Ok<GetCustomersQueryResult>, NotFound>> GetCustomers(
        [FromBody] GetCustomersRequest getCustomersRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var getCustomersQuery = new GetCustomersQuery(getCustomersRequest.CustomerIds);

        var results = await mediator.Send(
            getCustomersQuery,
            cancellationToken);

        if (!results.Customers.Any())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }

    public static async Task<Results<Ok<GetCustomersQueryResult>, NotFound>> GetCustomersV2(
        [FromBody] GetCustomersRequest getCustomersRequest,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var getCustomersQuery = new GetCustomersQuery(getCustomersRequest.CustomerIds);

        var results = await mediator.Send(
            getCustomersQuery,
            cancellationToken);

        if (!results.Customers.Any())
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
