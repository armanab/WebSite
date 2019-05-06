using AutoMapper;
using Package.Core.Domain.Application;
using Package.Core.Domain.Content;
using Package.Core.Domain.Media;
using Package.Core.DTO.Application;
using Package.Core.DTO.Media;
using Package.Core.DTO.Products;

namespace Package.UI.AutoMapper
{
    public class DomainAutoMapper : Profile
    {
        public DomainAutoMapper()
        {
            CreateMap<Picture, PictureViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<AboutUs, AboutUsViewModel>();
            CreateMap<ContactUs, ContactUsViewModel>();

            //CreateMap<EntityFrameworkCore.PagedList<Product>, ViewPagedList<ProductViewModel>>();


        }
    }
}
