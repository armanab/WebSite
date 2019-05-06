using Package.Core.Domain.Media;
using Package.Core.Entity;
using System;
using System.Collections.Generic;

namespace Package.Core.Domain.Content

{
    public class Product : IntBaseEntity
    {
        
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public DateTime InsertDate { get; set; }




    }
}
