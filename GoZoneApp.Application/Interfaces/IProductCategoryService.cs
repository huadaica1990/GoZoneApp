using GoZoneApp.Application.ViewModels.Product;

namespace GoZoneApp.Application.Interfaces
{
    public interface IProductCategoryService
    {
        #region BE
            void Save();
            void Delete(int id);
            void Update(ProductCategoryViewModel productCategoryVm);
        #endregion

        #region FE
            ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm);
            List<ProductCategoryViewModel> GetAll();
            List<ProductCategoryViewModel> GetAll(string keyword);
            List<ProductCategoryViewModel> GetAllByParentId(int parentId);
            ProductCategoryViewModel GetById(int id);
            void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
            void ReOrder(int sourceId, int targetId);
            List<ProductCategoryViewModel> GetHomeCategories(int top);
        #endregion

    }
}
