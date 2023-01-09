using GoZoneApp.Data.Entities;
using GoZoneApp.Infrastructure.Interfaces;

namespace GoZoneApp.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}
