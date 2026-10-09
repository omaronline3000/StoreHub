using StoreHub.Models;

namespace StoreHub.Repositories
{
    public interface ICategoryRepository
    {
        Category? GetById(int id);
    }
}
