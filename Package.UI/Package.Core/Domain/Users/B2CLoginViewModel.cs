using Gashtar.BookingEngine.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gashtar.BookingEngine.Common.User
{
    public class B2CLoginViewModel
    {
        [Icon("envelope-o")]
        public string Email { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
