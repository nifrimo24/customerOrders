
using Domain.OrderProducts;
using Domain.Orders;
using MediatR;
using Orders.Common;
using Orders.Common.Requests;

namespace Application.Orders.GetAll;


internal sealed class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IReadOnlyList<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderProductRepository _orderProductRepository;

    public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderProductRepository = orderProductRepository ?? throw new ArgumentNullException(nameof(orderProductRepository));
    }

    public async Task<IReadOnlyList<OrderResponse>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
{
    IReadOnlyList<Order> orders = await _orderRepository.GetAll();

    var orderResponses = new List<OrderResponse>();

    foreach (var order in orders)
    {
        var orderProducts = await _orderProductRepository.GetAllByIdAsync(order.Id);
        var orderResponse = new OrderResponse(
            order.Id.Value,
            order.CustomerId,
            orderProducts.Select(op => new OrderProductResponse(op.ProductId, op.UnitPrice, op.Quantity)).ToList(),
            order.Total,
            order.Address,
            order.Date
        );

        orderResponses.Add(orderResponse);
    }

    return orderResponses;
}

}