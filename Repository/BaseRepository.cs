using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		public Context Context { get; set; }

		public BaseRepository(Context context)
		{
			Context = context;
		}

		public IQueryable<T> FindAll()
		{
			return Context.Set<T>().AsNoTracking();
		}

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression).AsNoTracking();
		}

		public T? GetByCondition(Expression<Func<T, bool>> expression)
		{
			return Context.Set<T>().FirstOrDefault(expression);
		}

		public void Add(T entity)
		{
			Context.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			Context.Set<T>().Update(entity);
        }

		public void Delete(T entity)
		{
			Context.Set<T>().Remove(entity);
        }

	}
}
