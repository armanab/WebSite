using Gashtar.BookingEngine.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gashtar.BookingEngine.Common.User
{
    public class ChangePasswordWithTokenViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Token { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Icon("key")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
