using GoZoneApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoZoneApp.Data.Entities
{
    public class Tag : DomainEntity<string>
    {
        #region Basic
            [Required, StringLength(128)]
            public string Name { get; set; }
        #endregion
    }
}
