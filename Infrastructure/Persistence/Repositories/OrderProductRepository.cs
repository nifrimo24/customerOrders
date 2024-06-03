using Domain.OrderProducts;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly ApplicationDbContext _context;

    public OrderProductRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(OrderProduct orderProduct) => _context.OrderProducts.Add(orderProduct);

    public void Delete(OrderProduct orderProduct) => _context.OrderProducts.Remove(orderProduct);

    public void Update(OrderProduct orderProduct) => _context.OrderProducts.Update(orderProduct);

    public async Task<bool> ExistsAsync(OrderId orderId) => await _context.OrderProducts.AnyAsync(orderProduct => orderProduct.OrderId == orderId);

    public async Task<List<OrderProduct>?> GetAllByIdAsync(OrderId orderId) => await _context.OrderProducts.Where(orderProduct => orderProduct.OrderId == orderId).ToListAsync();
    
    public async Task<List<OrderProduct>> GetAll() => await _context.OrderProducts.ToListAsync();


}