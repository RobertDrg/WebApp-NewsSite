using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private NewsContext _newsContext;
        private INewsRepository? _newsRepository;
        private IAuthorRepository? _authorRepository;
        private INewspaperRepository? _newspaperRepository;
       // private IUserRepository? _userRepository;

        public INewsRepository NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_newsContext);
                }

                return _newsRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_newsContext);
                }

                return _authorRepository;
            }
        }

        public INewspaperRepository NewspaperRepository
        {
            get
            {
                if (_newspaperRepository == null)
                {
                    _newspaperRepository = new NewspaperRepository(_newsContext);
                }

                return _newspaperRepository;
            }
        }

        public RepositoryWrapper(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public void Save()
        {
            _newsContext.SaveChanges();
        }
    }
}