using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    [Table("Activities")]
    public class Activity : DomainEntity<int>, IDateTracking
    {
        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(255)]
            public string Name { get; set; }
            [StringLength(255), Column(TypeName = "varchar")]
            public string Url { get; set; }
            public string Description { get; set; }
            public LogController LogCategory { get; set; }
            public LogType Type { get; set; }
        #endregion

        #region Relationship
            [ForeignKey("AppUserId")]
            public AppUser AppUser { get; set; }
            public int AppUserId { get; set; }
        #endregion
    }
}
