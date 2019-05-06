using System;

namespace Package.Core.Entity
{
    [Serializable]

    public abstract class GuidBaseEntity : Entity<Guid>, IGuidBaseEntity
    {
        protected GuidBaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
