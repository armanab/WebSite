using AutoMapper;
using Package.Core.Domain.Application;
using Package.Core.Domain.Content;
using Package.Core.Domain.Media;
using Package.Core.DTO.Application;
using Package.Core.DTO.Media;
using Package.Core.DTO.Products;

namespace Package.UI.AutoMapper
{
    public class ModelAutoMapper : Profile
    {
        public ModelAutoMapper()
        {
            CreateMap<PictureViewModel, Picture>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<AboutUsViewModel, AboutUs>();
            CreateMap<ContactUsViewModel, ContactUs>();

            //CreateMap<EntityFrameworkCore.PagedList<Product>, ViewPagedList<ProductViewModel>>();


        }
    }
}
