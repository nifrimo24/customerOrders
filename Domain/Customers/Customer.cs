using Domain.Orders;
using Domain.Primitives;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public int Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{Name} {LastName}";

    public List<Order> Orders { get; private set; } = new List<Order>();

    public Customer(string name, string lastName)
    {
        this.Name = name;
        this.LastName = lastName;
    }

 

    public Customer() { }
}