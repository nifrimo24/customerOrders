using Domain.OrderProducts;
using Domain.Orders;
using Domain.Primitives;
using Domain.Products;
using Domain.ValueObjects;
using MediatR;

namespace Application.Orders.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<string> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var lastOrder = await _orderRepository.GetLastOrderAsync();
        var lastOrderId = lastOrder != null ? lastOrder.Id : new OrderId("OC-0");
        var id = Order.GetNextId(lastOrderId);

        var order = new Order(
            new OrderId(id),
            DateTime.Now,
            command.CustomerId,
            new List<OrderProduct>(),
            0,
            command.Address
        );

        foreach (var orderProductCommand in command.OrderProducts)
        {
            var unitPrice = (await _productRepository.GetByIdAsync(orderProductCommand.ProductId))!.UnitPrice;

            var orderProduct = new OrderProduct(order.Id, orderProductCommand.ProductId, unitPrice, orderProductCommand.Quantity);
            order.AddOrderProduct(orderProduct);
        }

        order.Total = Order.GetTotal(order.OrderProducts);

        _orderRepository.Add(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return order.Id.Value;
    }
}
