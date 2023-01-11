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
    public interface IAuthorService
    {
        IQueryable<Author> GetAllQueryable();
        IQueryable<Author> GetByCondition(Expression<Func<Author, bool>> expression);
        void CreateFromEntity(Author author);
        void UpdateFromEntity(Author author);
        void DeleteFromEntity(Author author);
        System.Threading.Tasks.Task SaveAsync();
    }
}
