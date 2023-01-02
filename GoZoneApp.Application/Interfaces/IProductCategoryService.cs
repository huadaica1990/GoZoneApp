using GoZoneApp.Application.ViewModels.Product;

namespace GoZoneApp.Application.Interfaces
{
    public interface IProductCategoryService
    {
        void Save();
        void Delete(int id);
        void Update(ProductCategoryViewModel productCategoryViewModel);

        ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryViewModel);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> GetAll(string keyword);
        List<ProductCategoryViewModel> GetAllByParentId(int parentId);
        ProductCategoryViewModel GetById(int id);
        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);
        List<ProductCategoryViewModel> GetHomeCategories(int top);
    }
}
