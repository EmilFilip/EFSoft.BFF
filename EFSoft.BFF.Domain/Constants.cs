namespace EFSoft.BFF.Domain;

public static class Constants
{
    public static class HttpClient
    {
        public const int HttpClientMaxRetries = 10;
        public const string CustomersServiceHttpCientName = "CustomersServiceHttpCientName";
        public const string OrdersServiceHttpCientName = "OrdersServiceHttpCientName";
        public const string InventoryServiceHttpCientName = "InventoryServiceHttpCientName";
        public const string ProductsServiceHttpCientName = "ProductsServiceHttpCientName";
        public const string HttpCientApplicationUrlencodedAcceptHeader = "application/x-www-form-urlencoded";

        public static class ApiRoutes
        {
            public const string CreateCustomerEndpoint = "api/customer/";
            public const string DeleteCustomerEndpoint = "api/customer/{customerId}";
            public const string GetAllCustomersEndpoint = "api/customer/get-all-customers";
            public const string GetCustomerEndpoint = "api/customer/{customerId}";
            public const string GetCustomersEndpoint = "api/customer/get-customers";
            public const string UpdateCustomerEndpoint = "api/customer/";

            public const string CreateInventoryEndpoint = "api/inventory/";
            public const string GetInventoryEndpoint = "api/inventory/{productId}";
            public const string UpdateInventoryEndpoint = "api/inventory/";

            public const string GetOrderEndpoint = "api/order/{orderId}";
            public const string GetCustomerOrdersEndpoint = "api/order/get-customer-orders/{customerId}";
            public const string CreateOrderEndpoint = "api/order/";
            public const string UpdateOrderEndpoint = "api/order/";
            public const string UpdateOrderStatusEndpoint = "api/order/status";
        }
    }
}
