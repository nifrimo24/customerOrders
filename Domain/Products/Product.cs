using Domain.OrderProducts;
using Domain.Orders;
using Domain.Primitives;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal UnitPrice { get; private set; } = 0;
    public int Stock { get; set; } = 0;


    public Product(string name, decimal unitPrice, int stock)
    {
        this.Name = name;
        this.UnitPrice = unitPrice;
        this.Stock = stock;
    }

    public Product() { }
}