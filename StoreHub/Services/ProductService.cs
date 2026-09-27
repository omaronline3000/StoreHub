using StoreHub.Repositories;

namespace StoreHub.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product>? GetAll()
        {
            return _productRepository.GetAll();
        }
        public Product? GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
            _productRepository.Save();

        }
        public void Update(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }
}
