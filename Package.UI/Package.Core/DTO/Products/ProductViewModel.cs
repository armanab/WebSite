using Package.Core.DTO.Media;
using System;
using System.Collections.Generic;

namespace Package.Core.DTO.Products
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<PictureViewModel> Pictures { get; set; }
        public DateTime InsertDate { get; set; }
    }
  
}
