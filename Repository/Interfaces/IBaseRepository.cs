using System.Linq.Expressions;

namespace Repository.Interfaces
{
	public interface IBaseRepository<T>
	{
		IQueryable<T> FindAll();
		IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression);
		T? GetByCondition(Expression<Func<T, bool>> expression);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
