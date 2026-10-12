using StoreHub.Models;

namespace StoreHub.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Product> Product { get; }
        IBaseRepository<Category> Category { get; }

        int Complete();

    }
}
