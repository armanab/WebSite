using Package.Core.Domain.Zone;
using Package.Core.Entity;

namespace Package.Core.Domain
{
    public class Town: IntBaseEntity
    {
        
        public string Name { get; set; }

        //public int CityId { get; set; }

        public City City { get; set; }
    }
}
