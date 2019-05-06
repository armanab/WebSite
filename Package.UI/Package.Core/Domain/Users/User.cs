using Package.Core.Entity;
using System;
using Microsoft.AspNetCore.Identity;

namespace Package.Core.Domain.Users
{
    public partial class User : IdentityUser<Guid>
    {
        public User()
        {
            //Id = Guid.NewGuid();
        }
        public User(string userName, string firstName, string lastName, string displayName)
        : base(userName)
        {
            base.Email = userName;

            this.FirstName = firstName;
            this.LastName = lastName;
            this.DisplayName = displayName;
            this.Index = 1;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public int Index { get; set; }
    }
}
