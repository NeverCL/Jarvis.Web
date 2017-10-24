using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Domain.Uow
{
    public interface IUnitOfWork
    {
        string Id { get; }

        void SaveChanges();
    }
}
