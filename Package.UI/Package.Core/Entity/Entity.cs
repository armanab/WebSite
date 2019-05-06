using System;

namespace Package.Core.Entity
{
    [Serializable]
    public abstract class Entity : IEntity
    {
    }

    [Serializable]
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {

        public TKey Id { get; set; }
    }
}
