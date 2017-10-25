using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public string Id { get; private set; }

        public abstract void SaveChanges();
    }
}
