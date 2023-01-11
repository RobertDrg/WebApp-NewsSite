using Site.Models;
using Site.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Site.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected NewsContext newsContext { get; set; }

        public RepositoryBase(NewsContext newsContext)
        {
            this.newsContext = newsContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.newsContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.newsContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.newsContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.newsContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.newsContext.Set<T>().Remove(entity);
        }
        public async Task SaveAsync()
        {
            await this.newsContext.SaveChangesAsync();
        }
    }
}