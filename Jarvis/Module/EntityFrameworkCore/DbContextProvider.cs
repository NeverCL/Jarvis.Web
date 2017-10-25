using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Module.Dependency;

namespace Module.EntityFrameworkCore
{
    public class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        private static ThreadLocal<TDbContext> _threadLocalDbContext;
        private readonly TDbContext _dbContext;


        public DbContextProvider(TDbContext dbContext)
        {
            _dbContext = dbContext;
            if (_threadLocalDbContext != null && _threadLocalDbContext.IsValueCreated)
                _dbContext = _threadLocalDbContext.Value;
            else
            {
                _threadLocalDbContext = new ThreadLocal<TDbContext> { Value = dbContext };
            }
        }

        public TDbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}
