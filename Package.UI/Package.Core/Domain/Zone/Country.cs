using Package.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Core.Domain.Zone
{
    public class Country:IntBaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
