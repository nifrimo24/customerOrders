using Domain.Products;

namespace Orders.Common.Requests;

public record OrderProductResponse(
    int ProductId,
    decimal UnitPrice,
    int Quantity
);