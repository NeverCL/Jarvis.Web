using System;
using Module.Dependency;
using Module.Domain.Entities;
using Module.EntityFrameworkCore;
using Module.EntityFrameworkCore.Repositories;
using Module.EntityFrameworkCore.Uow;

namespace Jarvis.EntityFrameworkCore
{
    public class JarvisRepository<TEntity, TPrimaryKey> : EfCoreRepositoryBase<JarvisDbContext, TEntity, TPrimaryKey>, ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public JarvisRepository(JarvisUnitOfWork unitOfWork) : base(unitOfWork.GetDbContext())
        {

        }
    }

    public class JarvisRepository<TEntity> : JarvisRepository<TEntity, string>
        where TEntity : class, IEntity<string>
    {
        public JarvisRepository(JarvisUnitOfWork unitOfWork) : base(unitOfWork)
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
