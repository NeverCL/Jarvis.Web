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
    public class EfUnitOfWork<TDbContext> : IUnitOfWork, ITransientDependency where TDbContext : DbContext
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        private readonly TDbContext _dbContext;

        private static ThreadLocal<TDbContext> _threadLocalDbContext;

        public EfUnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
            if (_threadLocalDbContext != null && _threadLocalDbContext.IsValueCreated)
                _dbContext = _threadLocalDbContext.Value;
            else
            {
                _threadLocalDbContext = new ThreadLocal<TDbContext> { Value = dbContext };
            }
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
