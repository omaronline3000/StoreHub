using StoreHub.Models;

namespace StoreHub.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<Product> Product { private set; get; }
        public IBaseRepository<Category> Category { private set; get; }
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
           _context = context;
            this.Product = new BaseRepository<Product>(_context);
            this.Category = new BaseRepository<Category>(_context);
        }
  
        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
