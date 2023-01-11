using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Models;
using Site.Repositories.Interfaces;
using Site.Services.Interfaces;
using System.Linq.Expressions;

namespace Site.Services
{

    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Author> GetAllQueryable()
        {
            return _repositoryWrapper.AuthorRepository.FindAll();
        }

        public IQueryable<Author> GetByCondition(Expression<Func<Author, bool>> expression)
        {
            return _repositoryWrapper.AuthorRepository.FindByCondition(expression);
        }

        public void CreateFromEntity(Author author)
        {
            _repositoryWrapper.AuthorRepository.Create(author);
        }

        public void UpdateFromEntity(Author author)
        {
            _repositoryWrapper.AuthorRepository.Update(author);
        }

        public void DeleteFromEntity(Author author)
        {
            _repositoryWrapper.AuthorRepository.Delete(author);
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.AuthorRepository.SaveAsync();
        }
    }
}
