using Microsoft.AspNetCore.Identity;
using Package.Core.Entity;
using System;
using System.Collections.Generic;

namespace Package.Core.Domain.Users
{
    public class Role : IdentityRole<Guid>, IGuidBaseWithIndexEntity
    {
        public Role()
        {
            Id = Guid.NewGuid();
			
        }

        public Role(string name) : this()
        {
            this.Name = name;
		
        }

       

        public string Description { get; set; }
        public int Index { get; set; }


        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        //ICollection<UserRole> _Users;
        //public override ICollection<UserRole> Users
        //{
        //    get
        //    {
        //        return _Users;
        //    }
        //}

        //public void SetUsers(ICollection<UserRole> users)
        //{
        //    this._Users = users;
        //}
    }
}
