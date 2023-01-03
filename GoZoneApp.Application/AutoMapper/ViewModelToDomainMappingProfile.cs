using AutoMapper;
using GoZoneApp.Application.ViewModels.Product;
using GoZoneApp.Data.Entities;

namespace GoZoneApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(
                    c.Name,
                    c.Description,
                    c.ParentId,
                    c.NoDeleted));
        }
    }
}
