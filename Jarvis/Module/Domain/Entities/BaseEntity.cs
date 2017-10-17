using System;
using System.Collections.Generic;

namespace Module.Domain.Entities
{
    public class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }

        public virtual bool IsTransient()
        {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(this.Id, default(TPrimaryKey)))
                return true;
            if (typeof(TPrimaryKey) == typeof(int))
                return Convert.ToInt32((object)this.Id) <= 0;
            if (typeof(TPrimaryKey) == typeof(long))
                return Convert.ToInt64((object)this.Id) <= 0L;
            return false;
        }
    }

    public class CreateEntity : CreateEntity<string>
    {
        //[StringLength(32)]
        public sealed override string Id { get; set; } = GuidBuilder.Build();
    }

    public class CreateEntity<TPrimaryKey> : BaseEntity<TPrimaryKey>
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }

}
