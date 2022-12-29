using GoZoneApp.Data.EF.Extensions;
using GoZoneApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoZoneApp.Data.EF.Configurations
{
    public class AppFunctionConfiguration : DbEntityConfiguration<AppFunction>
    {
        public override void Configure(EntityTypeBuilder<AppFunction> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired().HasColumnType("varchar(128)");
        }
    }
}
