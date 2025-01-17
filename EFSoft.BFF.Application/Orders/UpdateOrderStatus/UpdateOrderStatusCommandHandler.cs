namespace EFSoft.BFF.Application.Orders.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler(IHttpClientFactory httpClientFactory) : ICommandHandler<UpdateOrderStatusCommand>
{
    public async Task Handle(
        UpdateOrderStatusCommand command,
        CancellationToken cancellationToken)
    {
        //var order = new OrderDomainModel(command.OrderId);
        //order.SetOrderStatus(command.OrderStatus);

        //await updateOrderStatusRepository.UpdateOrderStatusAsync(
        //    order: order,
        //    cancellationToken: cancellationToken);

    }
}
