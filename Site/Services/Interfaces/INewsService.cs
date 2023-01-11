#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Models;
using System.Linq.Expressions;

namespace Site.Services.Interfaces
{
    public interface INewsService
    {
        //List<News> GetNewsByCategory(string searchString);
        IQueryable<News> GetAllQueryable();
        IQueryable<News> GetByCondition(Expression<Func<News, bool>> expression);
        IQueryable<News> GetNewsByTitle(string newsTitle);
        IQueryable<News> GetNewsById(int id);
        void CreateFromEntity(News news);
        void UpdateFromEntity(News news);
        void DeleteFromEntity(News news);
        System.Threading.Tasks.Task SaveAsync();
        IQueryable<Author> GetAuthors();
        IQueryable<Newspaper> GetNewspapers();
    }
}
