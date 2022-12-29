using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoZoneApp.Infrastructure.Interfaces
{
    public interface IHasSeo
    {
        [Required, StringLength(70)]
        string SeoPageTitle { get; set; }
        [Required, StringLength(255), Column(TypeName = "varchar")]
        string SeoAlias { get; set; }
        string SeoKeywords { get; set; }
        [StringLength(160)]
        string SeoDescription { get; set; }
        string SeoSchema { get; set;}
        string SeoRobot { get; set; }
    }
}
