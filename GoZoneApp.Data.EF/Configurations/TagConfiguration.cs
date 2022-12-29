using GoZoneApp.Data.EF.Extensions;
using GoZoneApp.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoZoneApp.Data.EF.Configurations
{
    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(128).IsRequired().HasColumnType("varchar(128)");
        }
    }
}
