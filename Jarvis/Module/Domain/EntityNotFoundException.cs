using System;
using System.Collections.Generic;
using System.Text;

namespace Module.Domain
{
    public class EntityNotFoundException : Exception
    {
        /// <summary>Type of the entity.</summary>
        public Type EntityType { get; set; }

        /// <summary>Id of the Entity.</summary>
        public object Id { get; set; }

        /// <summary>
        /// Creates a new <see cref="T:Abp.Domain.Entities.EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Creates a new <see cref="T:Abp.Domain.Entities.EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, (Exception)null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="T:Abp.Domain.Entities.EntityNotFoundException" /> object.
        /// </summary>
        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base(string.Format("There is no such an entity. Entity type: {0}, id: {1}", (object)entityType.FullName, id), innerException)
        {
            this.EntityType = entityType;
            this.Id = id;
        }
    }
}
