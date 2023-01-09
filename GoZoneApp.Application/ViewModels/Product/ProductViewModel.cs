using GoZoneApp.Data.Enums;

namespace GoZoneApp.Application.ViewModels.Product
{
    public class ProductViewModel
    {

        #region Auto
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        #region Basic
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Relationship
        public int CategoryId { get; set; }
        public ProductCategoryViewModel ProductCategory { set; get; }
        #endregion
    }
}
