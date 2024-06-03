using Domain.OrderProducts;
using Domain.Orders;
using Domain.Primitives;

namespace Domain.Products;

public sealed class Product : AggregateRoot
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal UnitPrice { get; private set; } = 0;


    public Product(string name, decimal unitPrice)
    {
        this.Name = name;
        this.UnitPrice = unitPrice;
    }

    public Product() { }
}