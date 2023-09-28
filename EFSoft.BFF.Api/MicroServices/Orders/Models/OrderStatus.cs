namespace EFSoft.BFF.Api.MicroServices.Orders.Models;

public enum OrderStatus
{
    None = 0,
    Open = 1,
    Dispatched = 2,
    Delivered = 3,
    Canceled = 4
}
