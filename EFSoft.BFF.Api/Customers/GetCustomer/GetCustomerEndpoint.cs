namespace EFSoft.BFF.Api.Customers.GetCustomer;

public static class GetCustomerEndpoint
{
    public static async Task<Results<Ok<GetCustomerQueryResult>, NotFound>> GetCustomer(
        [FromRoute] Guid customerId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var getCustomerQuery = new GetCustomerQuery(customerId);

        var results = await mediator.Send(
            getCustomerQuery,
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
