using System.Linq.Expressions;

namespace StoreHub.UnitOfWork.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            //var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
         
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().FirstOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, 
                      Expression<Func<T, object>> orderBy, 
                      int? take, int? skip, string OrderDirection, 
                      string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            query = query.Where(criteria);

            if (skip is not null) query =  query.Skip(skip.Value);
            if (take is not null) query =  query.Take(take.Value);

            if (OrderDirection == OrderByDirections.ASC) query =  query.OrderBy(orderBy);
            else if (OrderDirection == OrderByDirections.DES) query =  query.OrderByDescending(orderBy);

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
