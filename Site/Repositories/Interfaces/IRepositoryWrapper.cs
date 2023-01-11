namespace Site.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        INewsRepository NewsRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        INewspaperRepository NewspaperRepository { get; }
        void Save();
    }
}