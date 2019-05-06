using Gashtar.BookingEngine.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gashtar.BookingEngine.Common.User
{
    public class ChangePassword
    {
        [Icon("key")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
