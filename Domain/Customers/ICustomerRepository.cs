namespace Domain.Customers;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAll();
    
    Task<Customer?> GetByIdAsync(int id);
    
    Task<bool> ExistsAsync(int id);
    
    void Add(Customer customer);
    
    void Update(Customer customer);
    
    void Delete(Customer customer);
    
}