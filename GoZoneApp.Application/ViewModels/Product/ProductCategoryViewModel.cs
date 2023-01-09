namespace GoZoneApp.Application.ViewModels.Product
{
    public class ProductCategoryViewModel
    {

        #region Auto
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool NoDeleted { get; set; }
        #endregion

        #region Basic
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        #endregion

        #region Relationship
        public ICollection<ProductViewModel> Products { get; set; }
        #endregion
    }
}
