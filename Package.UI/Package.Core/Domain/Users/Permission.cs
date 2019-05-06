using Package.Core.Entity;

namespace Package.Core.Domain.Users
{
    public class Permission : IntBaseEntity
    {
        //public int PermissionGroupId { get; set; }
        public string Name { get; set; }
        public string TextName { get; set; }
        //public PermissionGroup PermissionGroup { get; set; }
        //public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
