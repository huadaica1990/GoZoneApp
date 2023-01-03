using AutoMapper;
using AutoMapper.QueryableExtensions;
using GoZoneApp.Application.Interfaces;
using GoZoneApp.Application.ViewModels.Product;
using GoZoneApp.Data.Entities;
using GoZoneApp.Data.Enums;
using GoZoneApp.Data.IRepositories;
using GoZoneApp.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GoZoneApp.Application.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productCategoryRepository = productCategoryRepository;
        }
        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                 .ProjectTo<ProductCategoryViewModel>(null).ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.FindAll(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>(null).ToList();
            else
                return _productCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                    .ProjectTo<ProductCategoryViewModel>(null)
                    .ToList();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.FindAll(x => x.ParentId == parentId)
             .ProjectTo<ProductCategoryViewModel>(null)
             .ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            return _mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository
                .FindAll(c => c.Products)
                  .OrderBy(x => x.Id)
                  .Take(top).ProjectTo<ProductCategoryViewModel>(null);

            var categories = query.ToList();
            foreach (var category in categories)
            {
                //category.Products = _productRepository
                //    .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.DateCreated)
                //    .Take(5)
                //    .ProjectTo<ProductViewModel>().ToList();
            }
            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
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
