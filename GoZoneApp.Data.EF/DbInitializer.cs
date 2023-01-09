using GoZoneApp.Data.Entities;
using GoZoneApp.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace GoZoneApp.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(
            AppDbContext context, 
            UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            #region Role
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "GoZoneAdmin",
                        NormalizedName = "GoZoneAdmin",
                        Description = "Super admin"
                    });
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Admin",
                        NormalizedName = "Admin",
                        Description = "Admin"
                    });
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Staff",
                        NormalizedName = "Staff",
                        Description = "Staff"
                    });
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Customer",
                        NormalizedName = "Customer",
                        Description = "Customer"
                    });
                }
            #endregion

            #region User
                if (!_userManager.Users.Any())
                {
                    await _userManager.CreateAsync(new AppUser()
                    {
                        UserName = "gozoneadmin",
                        Name = "GoZone Admin",
                        Email = "tronghuy2208@gmail.com",
                        Balance = 0,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Status = UserStatus.Active
                    }, "GOZOne!990");
                    var user = await _userManager.FindByNameAsync("gozoneadmin");
                    await _userManager.AddToRoleAsync(user, "GoZoneAdmin");

                    await _userManager.CreateAsync(new AppUser()
                    {
                        UserName = "admin",
                        Name = "Administrator",
                        Email = "admin@gmail.com",
                        Balance = 0,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Status = UserStatus.Active
                    }, "@dmIn2022");
                    var user1 = await _userManager.FindByNameAsync("admin");
                    await _userManager.AddToRoleAsync(user1, "Admin");
                }
            #endregion

            #region AppFunction
                if (_context.AppFunctions.Count() == 0)
                {
                    _context.AppFunctions.AddRange(new List<AppFunction>()
                    {
                        new AppFunction() {Id = "SYSTEM", Name = "Hệ thống", ParentId = null, SortOrder = 1, Status = Status.Active, Url = "/", Icon = "fa-desktop"},
                            new AppFunction() {Id = "ROLE", Name = "Quyền", ParentId = "SYSTEM", SortOrder = 1, Status = Status.Active, Url = "/admin/role/index", Icon = "fa-home"},
                            new AppFunction() {Id = "FUNCTION", Name = "Chức năng", ParentId = "SYSTEM", SortOrder = 2, Status = Status.Active, Url = "/admin/function/index", Icon = "fa-home"},
                            new AppFunction() {Id = "USER", Name = "Người dùng", ParentId = "SYSTEM", SortOrder = 3, Status = Status.Active, Url = "/admin/user/index", Icon = "fa-home"},
                            new AppFunction() {Id = "ACTIVITY", Name = "Nhật ký", ParentId = "SYSTEM", SortOrder = 4, Status = Status.Active, Url = "/admin/activity/index", Icon = "fa-home"},
                            new AppFunction() {Id = "SETTING", Name = "Cấu hình", ParentId = "SYSTEM", SortOrder = 5, Status = Status.Active, Url = "/admin/setting/index", Icon = "fa-home"},
                        
                        new AppFunction() {Id = "PRODUCT", Name = "Sản phẩm", ParentId = null, SortOrder = 2, Status = Status.Active, Url = "/", Icon = "fa-chevron-down"},
                            new AppFunction() {Id = "PRODUCT_CATEGORY", Name = "Danh mục", ParentId = "PRODUCT", SortOrder = 1, Status = Status.Active, Url = "/admin/productcategory/index", Icon = "fa-chevron-down"},
                            new AppFunction() {Id = "PRODUCT_LIST", Name = "Sản phẩm", ParentId = "PRODUCT", SortOrder = 2, Status = Status.Active, Url = "/admin/product/index", Icon = "fa-chevron-down"},
                        
                        new AppFunction() {Id = "UTILITY", Name = "Tiện ích", ParentId = null, SortOrder = 3, Status = Status.Active, Url = "/", Icon = "fa-clone"},
                            new AppFunction() {Id = "ANNOUNCEMENT", Name = "Thông báo", ParentId = "UTILITY", SortOrder = 1, Status = Status.Active, Url = "/admin/announcement/index", Icon = "fa-clone"},
                            new AppFunction() {Id = "CONTACT", Name = "Liên hệ", ParentId = "UTILITY", SortOrder = 2, Status = Status.Active, Url = "/admin/contact/index", Icon = "fa-clone"},
                        
                        new AppFunction() {Id = "TAG", Name = "Tags", ParentId = null, SortOrder = 4, Status = Status.Active, Url = "/admin/tag/index", Icon = "fa-chevron-down"},
                        new AppFunction() {Id = "PAGE", Name = "Trang tĩnh", ParentId = null, SortOrder = 5, Status = Status.Active, Url = "/admin/page/index", Icon = "fa-chevron-down"},

                        new AppFunction() {Id = "REPORT", Name = "Báo cáo", ParentId = null, SortOrder = 6, Status = Status.Active, Url = "/", Icon = "fa-bar-chart-o"},
                            new AppFunction() {Id = "REVENUES", Name = "Báo cáo doanh thu", ParentId = "REPORT", SortOrder = 1, Status = Status.Active, Url = "/admin/report/revenues", Icon = "fa-bar-chart-o"},
                            new AppFunction() {Id = "ACCESS", Name = "Báo cáo truy cập", ParentId = "REPORT", SortOrder = 2, Status = Status.Active, Url = "/admin/report/visitor", Icon = "fa-bar-chart-o"},
                            new AppFunction() {Id = "READER", Name = "Báo cáo độc giả", ParentId = "REPORT", SortOrder = 3, Status = Status.Active, Url = "/admin/report/reader", Icon = "fa-bar-chart-o"},
                    });
                }
            #endregion

            #region ProductCategory
                if (_context.ProductCategories.Count() == 0)
                {
                    List<ProductCategory> productCategory = new List<ProductCategory>()
                    {
                        new ProductCategory() {
                            Name = "Default", 
                            NoDeleted = true,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        },
                    };
                    _context.ProductCategories.AddRange(productCategory);
                }
            #endregion

            #region Configuration
                if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaTitle"))
                {
                    _context.SystemConfigs.Add(new SystemConfig()
                    {
                        Id = "HomeMetaTitle",
                        Name = "GoZone Title",
                        Value = "GoZone Title",
                        Status = Status.Active
                    });
                }
                if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
                {
                    _context.SystemConfigs.Add(new SystemConfig()
                    {
                        Id = "HomeMetaKeyword",
                        Name = "GoZone KeyWord",
                        Value = "GoZone KeyWord",
                        Status = Status.Active
                    });
                }
                if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
                {
                    _context.SystemConfigs.Add(new SystemConfig()
                    {
                        Id = "HomeMetaDescription",
                        Name = "GoZone Description",
                        Value = "GoZone Description",
                        Status = Status.Active
                    });
                }
            #endregion
            await _context.SaveChangesAsync();
        }
    }
}
