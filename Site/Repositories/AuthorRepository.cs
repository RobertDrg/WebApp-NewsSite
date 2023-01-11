using Microsoft.EntityFrameworkCore;
using Site.Models;
using Site.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Site.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(NewsContext newsContext)
            : base(newsContext)
        {
        }
        public override IQueryable<Author> FindAll()
        {
            return base.FindAll();
        }

        public override IQueryable<Author> FindByCondition(Expression<Func<Author, bool>> expression)
        {
            return base.FindAll().Where(expression).AsNoTracking();
        }
    }
}
