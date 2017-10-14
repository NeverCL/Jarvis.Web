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

    public class CreateEntity : BaseEntity<string>
    {
        [StringLength(32)]
        public sealed override string Id { get; set; }

        public CreateEntity()
        {
            Id = GuidBuilder.Build();
        }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
