namespace Package.Core.DTO.Media
{
    public class PictureViewModel
    {
        public int Id { get; set; }
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