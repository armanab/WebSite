using Package.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Core.Domain.Application
{
    public class ApplicationSetting : IntBaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
