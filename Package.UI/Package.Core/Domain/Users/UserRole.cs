using Microsoft.AspNetCore.Identity;
using Package.Core.Entity;
using System;

namespace Package.Core.Domain.Users
{
    public class UserRole : IdentityUserRole<Guid>, IEntity
	{
		public override Guid RoleId
		{
			get
			{
				return base.RoleId;
			}

			set
			{
				base.RoleId = value;
			}
		}
		public override Guid UserId
		{
			get
			{
				return base.UserId;
			}

			set
			{
				base.UserId = value;
			}
		}
		public User User { get; set; }
		public Role Role { get; set; }
	}
}
