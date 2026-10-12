using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace StoreHub.UnitOfWork.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();

        T Add(T entity);

        T Find(Expression<Func<T, bool>> criteria);

        IEnumerable<T> FindAll(Expression<Func<T,bool>> criteria, Expression<Func<T, object>> orderBy, int? take, int? skip, string direction , string[] includes = null);

        void Update(T entity);
        void Delete(T entity);

    }
}
