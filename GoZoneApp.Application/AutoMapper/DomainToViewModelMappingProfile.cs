using AutoMapper;
using GoZoneApp.Application.ViewModels.Product;
using GoZoneApp.Data.Entities;

namespace GoZoneApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
