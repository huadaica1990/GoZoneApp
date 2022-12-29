using GoZoneApp.Data.EF.Configurations;
using GoZoneApp.Data.EF.Extensions;
using GoZoneApp.Data.Entities;
using GoZoneApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoZoneApp.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options ): base(options) {}

        #region DbSet
            public DbSet<Contact> Contacts { get; set; }
            public DbSet<Activity> Activities { get; set; }
            public DbSet<Page> Pages { get; set; }
            public DbSet<SystemConfig> SystemConfigs { get; set; }
            public DbSet<Tag> Tags { get; set; }

            public DbSet<Announcement> Announcements { get; set; }
            public DbSet<AnnouncementUser> AnnouncementUsers { get; set; }

            public DbSet<ProductCategory> ProductCategories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductFunction> ProductFunctions { get; set; }
            public DbSet<ProductAndFunction> ProductAndFunctions { get; set; }

            public DbSet<AppUser> AppUsers { get; set; }
            public DbSet<AppRole> AppRoles { get; set; }
            public DbSet<AppPermission> AppPermissions { get; set; }
            public DbSet<AppFunction> AppFunctions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config
                builder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims").HasKey(x => x.Id);
                builder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
                builder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
                builder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
                builder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });
            #endregion

            #region Configuration
                builder.AddConfiguration(new AppFunctionConfiguration());
                builder.AddConfiguration(new SystemConfigConfiguration());
                builder.AddConfiguration(new TagConfiguration());
            #endregion
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach(EntityEntry item in modified)
            {
                var changeOrAddedItem = item.Entity as IDateTracking;
                if (changeOrAddedItem != null)
                {
                    if (item.State == EntityState.Added) changeOrAddedItem.DateCreated = DateTime.Now;
                    changeOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
