#nullable disable
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
    public class NewsService : INewsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public NewsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        //public List<News> GetNewsByCategory(string searchString)
        //{
        //    var news = new List<News>();

        //    if (searchString == "Liga1")
        //    {
        //        news = _repositoryWrapper.NewsRepository.FindByCondition(l => l.Category == "Liga1").ToList();
        //    }
        //    else if (searchString == "Tenis")
        //    {
        //        news = _repositoryWrapper.NewsRepository.FindByCondition(l => l.Category == "Tenis").ToList();
        //    }
        //    else if (searchString == "F1")
        //    {
        //        news = _repositoryWrapper.NewsRepository.FindByCondition(l => l.Category == "F1").ToList();
        //    }
        //    else if (searchString == "UCL")
        //    {
        //        news = _repositoryWrapper.NewsRepository.FindByCondition(l => l.Category == "UCL").ToList();
        //    }

        //    return news;
        //}

        public IQueryable<News> GetNewsByTitle(string newsTitle)
        {
            var newss = GetAllQueryable();

            if (!String.IsNullOrEmpty(newsTitle))
            {
                newss = _repositoryWrapper.NewsRepository.FindByCondition(s => s.NewsTitle!.Contains(newsTitle));
            }
            //else if (locationType == "textual_locations")
            //{
            //    locations = _repositoryWrapper.LocationRepository.FindByCondition(l => l.IsNumber == false).ToList();
            //}

            return newss;
        }

        public IQueryable<News> GetNewsById(int id)
        {
            var newss = GetAllQueryable();

            if (id != 0)
            {
                newss = _repositoryWrapper.NewsRepository.FindByCondition(c => c.NewsID == id);
            }
          
            return newss;
        }

        public IQueryable<News> GetAllQueryable()
        {
            return _repositoryWrapper.NewsRepository.FindAll();
        }

        public IQueryable<News> GetByCondition(Expression<Func<News, bool>> expression)
        {
            return _repositoryWrapper.NewsRepository.FindByCondition(expression);
        }

        public void CreateFromEntity(News news)
        {
            _repositoryWrapper.NewsRepository.Create(news);
        }

        public void UpdateFromEntity(News news)
        {
            _repositoryWrapper.NewsRepository.Update(news);
        }

        public void DeleteFromEntity(News news)
        {
            _repositoryWrapper.NewsRepository.Delete(news);
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.NewsRepository.SaveAsync();
        }

        public IQueryable<Author> GetAuthors()
        {
            return _repositoryWrapper.AuthorRepository.FindAll();
        }

        public IQueryable<Newspaper> GetNewspapers()
        {
            return _repositoryWrapper.NewspaperRepository.FindAll();
        }
    }
}