using Microsoft.EntityFrameworkCore;
using Site.Models;
using Site.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Site.Repositories
{
        public class NewspaperRepository : RepositoryBase<Newspaper>, INewspaperRepository
        {
            public NewspaperRepository(NewsContext newsContext)
                : base(newsContext)
            {
            }
            public override IQueryable<Newspaper> FindAll()
            {
                return base.FindAll();
            }

            public override IQueryable<Newspaper> FindByCondition(Expression<Func<Newspaper, bool>> expression)
            {
                return base.FindAll().Where(expression).AsNoTracking();
            }
        }
}