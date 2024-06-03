using MediatR;

namespace Application.Products.Create;

public record CreateProductCommand(
    string Name,
    decimal UnitPrice,
    int Stock
) : IRequest<int>;
