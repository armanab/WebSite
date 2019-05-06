using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gashtar.BookingEngine.Common.User
{
    public class ForgotPassword
    {
        [Gashtar.BookingEngine.Common.Attributes.Icon("envelope-o")]
        public string Email { get; set; }
    }
}
