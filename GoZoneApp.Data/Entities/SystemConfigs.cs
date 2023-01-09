using GoZoneApp.Data.Enums;
using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Data.Entities
{
    [Table("SystemConfigs")]
    public class SystemConfig : DomainEntity<string>, ISwitchable
    {
        #region Auto
            public Status Status { get; set; }
        #endregion

        #region Basic
            [Required, StringLength(128)]
            public string Name { get; set; }
            public string Value { get; set; }
        #endregion

    }
}
