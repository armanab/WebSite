using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Core.Entity
{
    public interface IGuidBaseWithIndexEntity : IGuidBaseEntity
    {
        int Index { get; set; }
    }
}
