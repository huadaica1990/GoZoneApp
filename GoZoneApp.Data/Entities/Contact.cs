using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    [Table("Contacts")]
    public class Contact : DomainEntity<int>, IDateTracking
    {
        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(255)]
            public string Name { get; set; }
            [StringLength(255)]
            public string Phone { get; set; }
            [StringLength(255)]
            public string Email { get; set; }
            public string Content { get; set; }
            [StringLength(255), Column(TypeName = "varchar")]
            public string Source { get; set; }
            [StringLength(255)]
            public string Longtitude { get; set; }
            [StringLength(255)]
            public string Latitude { get; set; }
            public ContactStatus Status { set; get; }
        #endregion
    }
}
