using MediatR;
using Orders.Common;

namespace Application.Orders.GetAll;

public record GetAllOrdersQuery() : IRequest<IReadOnlyList<OrderResponse>>;