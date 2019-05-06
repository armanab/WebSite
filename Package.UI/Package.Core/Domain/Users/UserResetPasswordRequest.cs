using Package.Core.Entity;
using System;

namespace Gashtar.BookingEngine.Common.User
{
    public class UserResetPasswordRequest : GuidBaseEntity
    {
        public Guid UserGuid { get; set; }
        public DateTime RequestedOn { get; set; }
        public string Token { get; set; }
    }
}
