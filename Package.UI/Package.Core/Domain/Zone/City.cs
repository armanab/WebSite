using Package.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Core.Domain.Zone
{
    public class City: IntBaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
