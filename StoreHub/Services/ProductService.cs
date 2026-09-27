using StoreHub.DTO;
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

        public Product Add(AddUpdateProductDTO productDTO)
        {
            Product product = new()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity
            };
            _productRepository.Add(product);
            _productRepository.Save();
            return product;

        }
        public Product? Update(int id, AddUpdateProductDTO productDTO)
        {
            var product = _productRepository.GetById(id);
            if (product is null) return null;
            product.id = id;
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.Quantity = productDTO.Quantity;
            _productRepository.Save();
            return product;
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }
}
