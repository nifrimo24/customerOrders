using Domain.Products;

namespace Orders.Common.Requests;

public record OrderProductRequest(
    int ProductId,
    int Quantity
);