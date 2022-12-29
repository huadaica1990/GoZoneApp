using GoZoneApp.Data.EF.Extensions;
using GoZoneApp.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoZoneApp.Data.EF.Configurations
{
    class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}
