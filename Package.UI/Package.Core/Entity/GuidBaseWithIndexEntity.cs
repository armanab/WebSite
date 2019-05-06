using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Core.Entity
{
    [Serializable]

    public class GuidBaseWithIndexEntity : GuidBaseEntity, IGuidBaseWithIndexEntity
    {
        public int Index { get; set; }
    }
}
