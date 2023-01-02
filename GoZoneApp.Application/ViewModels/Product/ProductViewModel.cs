using GoZoneApp.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required, DefaultValue(0)]
        public decimal Price { get; set; }
        #endregion

        #region Relationship
        [Required]
        public int CategoryId { get; set; }
        public ProductCategoryViewModel ProductCategory { set; get; }
        #endregion
    }
}
