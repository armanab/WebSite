using Package.Core.Entity;
using System.Collections.Generic;

namespace Package.Core.Domain.Users
{
    public class PermissionGroup : IntBaseEntity
    {
        public string Name { get; set; }
        public int Index { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
