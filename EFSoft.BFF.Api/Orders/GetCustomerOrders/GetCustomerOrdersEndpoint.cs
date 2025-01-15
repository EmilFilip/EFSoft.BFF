namespace EFSoft.BFF.Api.Orders.GetCustomerOrders;

public static class GetCustomerOrdersEndpoint
{
    public static async Task<Results<Ok<GetCustomerOrdersQueryResult>, NotFound>> GetCustomerOrders(
        Guid customerId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var results = await mediator.Send(
            new GetCustomerOrdersQuery(customerId),
            cancellationToken);

        if (results == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}
