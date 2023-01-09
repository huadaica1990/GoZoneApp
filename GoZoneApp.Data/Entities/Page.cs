using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    [Table("Pages")]
    public class Page : DomainEntity<int>, IDateTracking, INoDelete, ISwitchable
    {
        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
            public bool NoDeleted { get; set; }
            public Status Status { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(255)]
            public string Name { get; set; }
            public string Content { get; set; }
            public bool? IsHtml { get; set; }
            public string ExtensionField { get; set; }
        #endregion
    }
}
