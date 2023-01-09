using GoZoneApp.Data.EF.Extensions;
using GoZoneApp.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoZoneApp.Data.EF.Configurations
{
    public class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired().HasMaxLength(128);
        }
    }
}
