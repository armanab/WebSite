using Package.Core.Entity;
using System;

namespace Package.Core.Domain.Users
{
    public class RolePermission : IntBaseEntity
    {
        public Guid RoleId { get; set; }
        //public int PermissionId { get; set; }
        public AccessType AccessType { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
