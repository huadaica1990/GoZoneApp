using System.ComponentModel.DataAnnotations;

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
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        #endregion

        #region Relationship

        public ICollection<ProductViewModel> Products { set; get; }
        #endregion
    }
}
