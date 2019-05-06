using Package.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Package.Service.Media
{
    public interface IPictureService : IService<Picture>
    {
      
        string GetImageUrl(Picture picture);
        string GetThumbnailImageUrl(Picture picture);
        void Initialize();
        
        void DeleteNotUsedPictures();
        IEnumerable<Picture> Get(Expression<Func<Picture, bool>> p);
    }
}
