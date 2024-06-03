using Domain.Customers;
using Domain.OrderProducts;
using Domain.Primitives;
using Domain.Products;
using Domain.ValueObjects;

namespace Domain.Orders;

public sealed class Order : AggregateRoot
{
    public OrderId Id { get; private set; }
    public DateTime Date { get; private set; }
    public int CustomerId { get; private set; }
    public List<OrderProduct> OrderProducts { get; private set; }
    public decimal Total { get; set; }
    public string Address { get; private set; }

    public Customer Customer { get; private set; }


    public Order(OrderId Id, DateTime date, int customerId, List<OrderProduct> orderProducts, decimal total, string address)
    {
        this.Id = Id;
        this.Date = date;
        this.CustomerId = customerId;
        this.OrderProducts = orderProducts;
        this.Total = total;
        this.Address = address;
    }

    public void AddOrderProduct(OrderProduct orderProduct)
    {
        this.OrderProducts.Add(orderProduct);
    }

    public static string GetNextId(OrderId lastId)
    {
        var lastIdValue = lastId != null ? int.Parse(lastId.Value.Substring(3)) : 0;
        return $"OC-{lastIdValue + 1}";
    }

    public static decimal GetTotal(List<OrderProduct> orderProducts)
    {
        decimal total = 0;

        foreach (var orderProduct in orderProducts)
        {
            total += orderProduct.Quantity * orderProduct.UnitPrice;
        }

        return total;
    }

    public static Order UpdateOrder(string orderId, int customerId, List<OrderProduct> orderProducts, string address)
    {
        return new Order(new OrderId(orderId), DateTime.Now, customerId, orderProducts, GetTotal(orderProducts), address);
    }

    public Order() { }
}