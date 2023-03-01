using System.Linq.Expressions;

namespace PortfolioTracker.Interface
{
    public interface IRepositoyBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
