using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jarvis.Core.Module
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }

    public class CreateEntity : CreateEntity<string>
    {
        [StringLength(32)]
        public sealed override string Id { get; set; } = GuidBuilder.Build();
    }

    public class CreateEntity<T> : BaseEntity<T>
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }

}
