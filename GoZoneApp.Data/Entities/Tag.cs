using GoZoneApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoZoneApp.Data.Entities
{
    [Table("Tags")]
    public class Tag : DomainEntity<string>
    {
        #region Basic
            [Required, StringLength(50)]
            public string Name { get; set; }
        #endregion
    }
    [Table("ProductTags")]
    public class ProductTag : DomainEntity<int>
    {
        #region Relationship
        public int ProductId { get; set; }
        [StringLength(50), Column(TypeName = "varchar")]
        public string TagId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
        #endregion
    }
}
