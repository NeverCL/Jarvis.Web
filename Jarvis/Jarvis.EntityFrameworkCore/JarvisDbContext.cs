using Jarvis.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.EntityFrameworkCore
{
    public class JarvisDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public JarvisDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Core.Joke.Joke> Jokes { get; set; }

        public DbSet<Core.Company.Company> Companies{ get; set; }

        public DbSet<Core.Company.CompanyListUrl> CompanyListUrls{ get; set; }

        public DbSet<Core.HttpData.HttpData> HttpDatas { get; set; }
    }
}
