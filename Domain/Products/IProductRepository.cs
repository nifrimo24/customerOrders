namespace Domain.Products;

public interface IProductRepository
{
    Task<List<Product>> GetAll();

    Task<Product?> GetByIdAsync(int id);

    Task<bool> ExistsAsync(int id);

    void Add(Product product);

    void Update(Product product);

    void Delete(Product product);

}