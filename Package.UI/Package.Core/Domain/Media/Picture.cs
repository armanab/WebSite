using Package.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Core.Domain.Media
{
    public class Picture : IntBaseEntity
    {
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public string ThumbnailFileName { get; set; }
        public string FileName { get; set; }
        public string RelativePath { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Description { get; set; }
    }
}
