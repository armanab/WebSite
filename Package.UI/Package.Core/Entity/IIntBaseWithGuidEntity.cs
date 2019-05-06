using System;
namespace Package.Core.Entity
{
    public interface IIntBaseWithGuidEntity : IIntBaseEntity
    {
        Guid Guid { get; set; }
    }
}
