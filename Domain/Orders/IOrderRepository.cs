namespace Domain.Orders;

public interface IOrderRepository
{
    Task<List<Order>> GetAll();
    
    Task<Order?> GetByIdAsync(OrderId id);
    
    Task<bool> ExistsAsync(OrderId id);
    
    void Add(Order order);
    
    void Update(Order order);
    
    void Delete(Order order);

    Task<Order?> GetLastOrderAsync();
    
}