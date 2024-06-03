using Domain.OrderProducts;
using Domain.Orders;
using Orders.Common.Requests;

namespace Orders.Common;

public record OrderResponse(
    string Id,
    int CustomerId,
    List<OrderProductResponse> OrderProducts,
    decimal Total,
    string Address,
    DateTime Date
);