namespace StoreHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Refrential type behavior Loop


            // Query Filter
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }

    }
}
