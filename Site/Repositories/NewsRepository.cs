using Microsoft.EntityFrameworkCore;
using Site.Models;
using Site.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Site.Repositories
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(NewsContext newsContext)
            : base(newsContext)
        {
        }
        //public override IQueryable<News> FindAll()
        //{
        //    return base.FindAll().Include(x => x.Author);
        //}

        //public override IQueryable<News> FindByCondition(Expression<Func<News, bool>> expression)
        //{
        //    return base.FindAll().Include(x => x.Author).Where(expression).AsNoTracking();
        //}
    }
}