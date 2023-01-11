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
    public interface INewspaperService
    {
        IQueryable<Newspaper> GetAllQueryable();
        IQueryable<Newspaper> GetByCondition(Expression<Func<Newspaper, bool>> expression);
        void CreateFromEntity(Newspaper newspaper);
        void UpdateFromEntity(Newspaper newspaper);
        void DeleteFromEntity(Newspaper newspaper);
        System.Threading.Tasks.Task SaveAsync();
    }
}
