using Package.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Core.Domain.Application
{
    public class ContactUs : IntBaseEntity
    { 
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
