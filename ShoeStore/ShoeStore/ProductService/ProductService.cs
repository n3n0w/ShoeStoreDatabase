using ShoeStore.Models;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync() => _repository.GetAllAsync();

    public Task<Product> GetProductByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task AddProductAsync(Product product) => _repository.AddAsync(product);

    public Task UpdateProductAsync(Product product) => _repository.UpdateAsync(product);

    public Task DeleteProductAsync(int id) => _repository.DeleteAsync(id);
}