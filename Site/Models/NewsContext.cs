using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Site.Models
{
    public class NewsContext : IdentityDbContext<IdentityUser>
    {
        public NewsContext(DbContextOptions<NewsContext> options)

        : base(options)

        { }

        //public DbSet<User>? Users { get; set; }

        //public DbSet<Login>? Logins { get; set; }

        public DbSet<News>? News { get; set; }

        public DbSet<Author>? Authors { get; set; }

        public DbSet<Newspaper>? Newspapers { get; set; }

        public DbSet<Comment>? Comments { get; set; }
    }
}
