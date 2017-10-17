using System;
using Module.Domain.Entities;
using Module.EntityFrameworkCore.Repositories;

namespace Jarvis.EntityFrameworkCore
{
    public class JarvisRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<JarvisDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public JarvisRepositoryBase(JarvisDbContext dbContext) : base(dbContext)
        {
        }
    }
}
