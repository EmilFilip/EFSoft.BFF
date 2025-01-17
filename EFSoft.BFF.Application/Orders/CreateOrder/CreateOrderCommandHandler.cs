namespace EFSoft.BFF.Application.Orders.CreateOrder;

public class CreateOrderCommandHandler(IHttpClientFactory httpClientFactory) : ICommandHandler<CreateOrderCommand>
{
    public async Task Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        //var order = OrderDomainModel.CreateNew(
        //    description: command.Description,
        //    customerId: command.CustomerId);

        //await createOrderRepository.CreateOrderAsync(
        //    order,
        //    cancellationToken);

        //var orderProducts = new List<OrderProductDomainModel>();

        //foreach (var orderProduct in command.OrderProducts)
        //{
        //    var newOrderProduct = OrderProductDomainModel.CreateNew(
        //        orderId: order.OrderId,
        //        productId: orderProduct.ProductId,
        //        quantity: orderProduct.Quantity);

        //    orderProducts.Add(newOrderProduct);
        //}

        //await createOrderProductRepository.CreateOrderProductAsync(
        //    orderProducts,
        //    cancellationToken);
    }
}
