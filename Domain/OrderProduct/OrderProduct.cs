using System.Text.Json.Serialization;
using Domain.Orders;
using Domain.Primitives;
using Domain.Products;

namespace Domain.OrderProducts;

public class OrderProduct : AggregateRoot
{
    public OrderId OrderId { get; private set; }
    public int ProductId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }


    public Order Order { get; private set; }
    public Product Product { get; private set; }

    public OrderProduct(OrderId orderId, int productId, decimal unitPrice, int quantity)
    {
        this.OrderId = orderId;
        this.ProductId = productId;
        this.UnitPrice = unitPrice;
        this.Quantity = quantity;
    }

    public OrderProduct() { }
}