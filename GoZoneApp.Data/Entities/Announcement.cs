using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    [Table("Announcements")]
    public class Announcement : DomainEntity<string>, IDateTracking, ISwitchable
    {
        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
            public Status Status { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(250)]
            public string Name { get; set; }
            [StringLength(250)]
            public string Content { get; set; }
        #endregion


        #region Relationship
            public Guid UserId { get; set; }
            [ForeignKey("UserId")]
            public virtual AppUser AppUser { get; set; }

            public Announcement()
            {
                AnnouncementUsers = new List<AnnouncementUser>();
            }
            public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
        #endregion

    }

    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<int>
    {
        #region Basic
            public bool? HasRead { get; set; }
        #endregion

        #region Relationship
            public Guid UserId { get; set; }

            [Required, StringLength(128)]
            public string AnnouncementId { get; set; }
            [ForeignKey("AnnouncementId")]
            public virtual Announcement Announcement { get; set; }
        #endregion
    }
}
