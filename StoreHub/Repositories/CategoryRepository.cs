using StoreHub.Models;

namespace StoreHub.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public Category? GetById(int id)
        {
            return _context.categories
                .Include(c => c.products)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
