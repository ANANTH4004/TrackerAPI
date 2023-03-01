using Microsoft.EntityFrameworkCore;
using PortfolioTracker.Interface;
using PortfolioTracker.Models;
using System.Linq.Expressions;

namespace PortfolioTracker.Repository
{
    public class RepositoryBase<T> : IRepositoyBase<T> where T : class
    {
        private readonly TrackerContext _tracker;
        public RepositoryBase(TrackerContext tracker)
        {
            _tracker = tracker;
        }
        public T Create(T entity)
        {
            
           _tracker.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll() => _tracker.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
         return _tracker.Set<T>().Where(expression);
        }
        public T Update(T entity)
        {
            _tracker.Set<T>().Update(entity);
            return entity;
        }
    }
}
