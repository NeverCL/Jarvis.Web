using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.Core
{
    public class JarvisDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public JarvisDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Joke.Joke> Jokes { get; set; }
    }
}
