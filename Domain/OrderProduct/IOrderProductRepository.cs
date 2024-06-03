using Domain.Orders;
using Domain.Products;

namespace Domain.OrderProducts;

public interface IOrderProductRepository
{
    Task<List<OrderProduct>> GetAll();
    
    Task<List<OrderProduct>?> GetAllByIdAsync(OrderId orderId);
    
    Task<bool> ExistsAsync(OrderId orderId);
    
    void Add(OrderProduct orderProduct);
    
    void Update(OrderProduct orderProduct);
    
    void Delete(OrderProduct orderProduct);
}
