using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>, IDateTracking, INoDelete
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public ProductCategory(string name, string? description, int? parentId)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
        }


        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
            public bool NoDeleted { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(255)]
            public string Name { get; set; }
            [StringLength(255)]
            public string? Description { get; set; }
            public int? ParentId { get; set; }
        #endregion

        #region Relationship
            public virtual ICollection<Product> Products { set; get; }
        #endregion
    }

    [Table("Products")]
    public class Product : DomainEntity<int>, IDateTracking, ISwitchable, IHasSoftDelete
    {
        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
            public Status Status { get; set; }
            public bool IsDeleted { get; set; }
        #endregion

        #region Basic
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
            [ForeignKey("CategoryId")]
            public virtual ProductCategory ProductCategory { set; get; }
        #endregion
    }

    [Table("ProductFunctions")]
    public class ProductFunction : DomainEntity<int>, ISwitchable, IHasSoftDelete
    {
        #region Auto
            public Status Status { get; set; }
            public bool IsDeleted { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(255)]
            public string Name { get; set; }
            [StringLength(255)]
            public string Description { get; set; }
            [Required, DefaultValue(0)]
            public decimal Price { get; set; }
        #endregion
    }

    [Table("ProductAndFunctions")]
    public class ProductAndFunction : DomainEntity<int>, ISortable, ISwitchable
    {
        #region Auto
            public int SortOrder { get; set; }
            public Status Status { get; set; }
        #endregion

        #region Basic
            [DefaultValue(0)]
            public decimal Price { get; set; }
        #endregion

        #region Relationship
            [ForeignKey("ProductId")]
            public virtual Product Product { get; set; }

            [ForeignKey("ProductFunctionId")]
            public virtual ProductFunction ProductFunction { get; set; }
        #endregion
    }
}
