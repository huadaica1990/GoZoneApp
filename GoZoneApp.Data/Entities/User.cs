using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IDateTracking
    {
        #region Auto
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
        #endregion

        #region Basic
            public string Name { get; set; }
            public DateTime? BirthDay { get; set; }
            public string Avatar { get; set; }
            [DefaultValue(0)]
            public decimal Balance { get; set; }
            public UserStatus Status { get; set; }
        #endregion
    }

    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base() { }
        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }
        [StringLength(250)]
        public string Description { get; set; }
    }

    [Table("GoZonePermissions")]
    public class AppPermission : DomainEntity<int>
    {
        #region Basic
            public bool CanCreate { get; set; }
            public bool CanRead { get; set; }

            public bool CanUpdate { get; set; }
            public bool CanDelete { get; set; }
        #endregion

        #region Relationship
            [Required]
            public Guid RoleId { get; set; }
            [ForeignKey("RoleId")]
            public virtual AppRole AppRole { get; set; }

            [Required, StringLength(128)]
            public string AppFunctionId { get; set; }
            [ForeignKey("AppFunctionId")]
            public virtual AppFunction AppFunction { get; set; }
        #endregion
    }

    [Table("GoZoneFunctions")]
    public class AppFunction : DomainEntity<string>, ISortable, ISwitchable
    {
        public AppFunction() { }
        public AppFunction(string name, string url, string parentId, string icon, int sortOrder)
        {
            this.Name = name;
            this.Url = url;
            this.ParentId = parentId;
            this.Icon = icon;
            this.SortOrder = sortOrder;
            this.Status = Status.Active;
        }
        #region Auto
            public int SortOrder { get; set; }
            public Status Status { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(128)]
            public string Name { get; set; }
            [Required, StringLength(250)]
            public string Url { get; set; }
            [StringLength(128)]
            public string ParentId { get; set; }
            public string Icon { get; set; }
        #endregion
    }
}
