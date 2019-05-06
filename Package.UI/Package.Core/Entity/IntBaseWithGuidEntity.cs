using System;

namespace Package.Core.Entity
{
    [Serializable]
    public abstract class IntBaseWithGuidEntity : IntBaseEntity, IIntBaseWithGuidEntity
    {
        public IntBaseWithGuidEntity()
        {
            do
            {
                Guid = Guid.NewGuid();
            } while (Guid == Guid.Empty);
        }
        public Guid Guid { get; set; }
    }
}
