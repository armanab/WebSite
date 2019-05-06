using Gashtar.BookingEngine.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gashtar.BookingEngine.Common.User
{
    public class B2CRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Icon("envelope-o")]
        public string Email { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
