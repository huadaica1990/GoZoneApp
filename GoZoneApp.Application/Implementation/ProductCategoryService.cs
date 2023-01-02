using GoZoneApp.Application.Interfaces;
using GoZoneApp.Application.ViewModels.Product;
using GoZoneApp.Data.IRepositories;
using GoZoneApp.Infrastructure.Interfaces;

namespace GoZoneApp.Application.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(
            IUnitOfWork unitOfWork,
            IProductCategoryRepository productCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _productCategoryRepository = productCategoryRepository;
        }
        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            throw new NotImplementedException();
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategoryViewModel productCategoryViewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}
