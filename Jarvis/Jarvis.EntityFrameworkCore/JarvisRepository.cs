using System;
using Module.Dependency;
using Module.Domain.Entities;
using Module.EntityFrameworkCore;
using Module.EntityFrameworkCore.Repositories;
using Module.EntityFrameworkCore.Uow;

namespace Jarvis.EntityFrameworkCore
{
    public class JarvisRepository<TEntity, TPrimaryKey> : EfCoreRepositoryBase<JarvisDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public JarvisRepository(IDbContextProvider<JarvisDbContext> dbContextProvider) : base(dbContextProvider.GetDbContext())
        {

        }
    }

    public class JarvisRepository<TEntity> : JarvisRepository<TEntity, string>
        where TEntity : class, IEntity<string>
    {
        public JarvisRepository(IDbContextProvider<JarvisDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class JarvisUnitOfWork : EfUnitOfWork<JarvisDbContext>, ITransientDependency
    {
        public JarvisUnitOfWork(JarvisDbContext dbContext) : base(dbContext)
        {
        }
    }


}
