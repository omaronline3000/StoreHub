using StoreHub.Repositories;
using StoreHub.DTO;
namespace StoreHub.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryRetrivalDTO GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            var data = new CategoryRetrivalDTO()
            {
                Id = category.Id,
                Name = category.Name,
                ProductsName = category.products?.Select(p => p.Name).ToList()
            };
            return data;
        }
    }
}
