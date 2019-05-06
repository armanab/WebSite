using Package.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Core.DTO.Application
{
    public class AboutUsViewModel
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
