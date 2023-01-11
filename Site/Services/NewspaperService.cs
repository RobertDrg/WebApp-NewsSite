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

    public class NewspaperService : INewspaperService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public NewspaperService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Newspaper> GetAllQueryable()
        {
            return _repositoryWrapper.NewspaperRepository.FindAll();
        }

        public IQueryable<Newspaper> GetByCondition(Expression<Func<Newspaper, bool>> expression)
        {
            return _repositoryWrapper.NewspaperRepository.FindByCondition(expression);
        }

        public void CreateFromEntity(Newspaper newspaper)
        {
            _repositoryWrapper.NewspaperRepository.Create(newspaper);
        }

        public void UpdateFromEntity(Newspaper newspaper)
        {
            _repositoryWrapper.NewspaperRepository.Update(newspaper);
        }

        public void DeleteFromEntity(Newspaper newspaper)
        {
            _repositoryWrapper.NewspaperRepository.Delete(newspaper);
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.NewspaperRepository.SaveAsync();
        }
    }
}
