using System;

namespace Package.Core.Entity
{
    [Serializable]

    public abstract class IntBaseEntity : Entity<int>, IIntBaseEntity
    {
    }
}
