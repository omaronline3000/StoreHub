namespace StoreHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Loop 

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }

    }
}
