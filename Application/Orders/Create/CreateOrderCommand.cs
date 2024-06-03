using MediatR;
using Orders.Common.Requests;

namespace Application.Orders.Create;

public record CreateOrderCommand(
    int CustomerId,
    List<OrderProductRequest> OrderProducts,
    string Address
) : IRequest<string>;
