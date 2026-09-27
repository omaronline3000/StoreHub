namespace StoreHub.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product>? GetAll()
        {
            return _context.products.ToList();
        }
        public Product? GetById(int id)
        {
            return _context.products.FirstOrDefault(p => p.id == id);
        }

        public void Add(Product product)
        {
            _context.products.Add(product);
            
        }
        public void Update(Product product)
        {
            _context.products.Update(product);
        }
        public void Delete(int id)
        {
            _context.products.Find(id)!.IsDeleted = true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
