using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Module.Dependency;
using Module.Domain.Uow;

namespace Module.EntityFrameworkCore.Uow
{
    public class EfUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        private readonly TDbContext _dbContext;

        public EfUnitOfWork(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }

        public virtual TDbContext GetDbContext()
        {
            return _dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
