using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Areas.Blog.Models;
using MyBlog.Areas.Categories.Models;
using MyBlog.Areas.Database.Models;
using MyBlog.Database;
using MyBlog.Models.UserModels;

namespace MyBlog.Areas_Database_Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    [Authorize(Roles = "Admin")]
    public class DbManageController : Controller
    {
        private readonly MyBlogDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbManageController(MyBlogDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Index()
        {
            var connect = _context.Database.GetDbConnection();
            connect.Open();

            var dbInfoModel = new DbInfoModel()
            {
                DbName = connect.Database,
                DataSource = connect.DataSource,
                CanConnect = _context.Database.CanConnect(),
                AppliedMigrations = (await _context.Database.GetAppliedMigrationsAsync()).ToList(),
                PendingMigrations = (await _context.Database.GetPendingMigrationsAsync()).ToList(),
                DataTableName = (await connect.GetSchemaAsync("tables")).Rows
            };

            connect.Close();

            return View(dbInfoModel);
        }

        [AllowAnonymous]
        public IActionResult CreateDefaultData()
        {
            if (!_context.Database.CanConnect())
            {
                _context.Database.EnsureCreated();

                _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });

                _userManager.CreateAsync(new AppUser() { UserName = "admin" }, "admin");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteSampleData()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteSampleData")]
        public async Task<IActionResult> DeleteSampleDataAsync()
        {
            //Remove sample User
            _context.Users.RemoveRange(_context.Users.Where(u => u.UserName.Contains("[FakeUser]")));
            //Remove sample Category
            _context.Categories.RemoveRange(_context.Categories.Where(c => c.Title.Contains("[FakeCategory]")));

            //Remove sample Blog
            _context.Blogs.RemoveRange(_context.Blogs.Where(b => b.Title.Contains("[FakeBlog]")));

            //Remove sample BlogCategory
            var listblogCategory = await _context.BlogCategory
                .Include(bc => bc.Category)
                .Include(bc => bc.Blog)
                .Where(bc => bc.Category.Title.Contains("[FakeCategory]") && bc.Blog.Title.Contains("[Fakedata]"))
                .ToListAsync();

            _context.BlogCategory.RemoveRange(listblogCategory);

            await _context.SaveChangesAsync();

            StatusMessage = "Xóa dữ liệu mẫu thành công!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateSampleData()
        {
            var createSampleDataModel = new CreateSampleDataModel();

            return View(createSampleDataModel);
        }

        [HttpPost, ActionName("CreateSampleData")]
        public async Task<IActionResult> CreateSampleDataAsync(CreateSampleDataModel createSampleDataModel)
        {
            int index = 1; //Index to create names

            //Create sample data for User
            var fakerUser = new Faker<AppUser>();

            fakerUser.RuleFor(u => u.UserName, f => $"[FakeUser]{index++}");

            var listUser = new List<AppUser>();

            for(int i =1; i <= createSampleDataModel.NumberOfUser; i++)
            {
                var fuser = fakerUser.Generate();

                listUser.Add(fuser);
            }

            await _context.AddRangeAsync(listUser);

            //Create sample data for Category
            index = 1;
            var fakerCategory = new Faker<CategoryModel>();

            fakerCategory.RuleFor(c => c.Title, f => $"[FakeCategory]{index++}");
            fakerCategory.RuleFor(c => c.Content, f => f.Lorem.Sentence(5));
            fakerCategory.RuleFor(c => c.Slug, f => f.Lorem.Slug());

            var categories = new List<CategoryModel>();
            for (int i = 1; i<= createSampleDataModel.NumberOfCategory; i++)
            {
                var cate = fakerCategory.Generate();
                categories.Add(cate);

                if (i % 3 != 1)
                {
                    categories[i - 1].ParentCategory = categories[i - 2];
                }
            }
            
            await _context.AddRangeAsync(categories);
            await _context.SaveChangesAsync();

            //Create sample data for Blog
            index = 1;
            var randomId = new Random();
            var user = await _userManager.GetUserAsync(User);

            var fakerBlog = new Faker<BlogModel>();

            fakerBlog.RuleFor(b => b.Title, f => $"[FakeBlog]Bài {index++}:" + f.Lorem.Sentence(2, 3).Trim('.'));
            fakerBlog.RuleFor(b => b.Description, f => f.Lorem.Sentence(3).Trim('.'));
            fakerBlog.RuleFor(b => b.Slug, f => f.Lorem.Slug());
            fakerBlog.RuleFor(b => b.Content, f => f.Lorem.Paragraphs(5));
            fakerBlog.RuleFor(b => b.Published , f => true);
            fakerBlog.RuleFor(b => b.AuthorId, f => user.Id);
            fakerBlog.RuleFor(b => b.DateCreated, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2022, 1, 1)));

            List<BlogModel> blogModels = new List<BlogModel>();
            List<BlogCategory> blogCategories = new List<BlogCategory>();

            for (int i=1; i < createSampleDataModel.NumberOfBlog; i++)
            {
                var blog = fakerBlog.Generate();

                blog.DateUpdated = blog.DateCreated;

                blogModels.Add(blog);

                blogCategories.Add(new BlogCategory() { Blog = blog, Category = categories[randomId.Next(createSampleDataModel.NumberOfCategory - 1)] });
            }

            await _context.AddRangeAsync(blogModels);
            await _context.AddRangeAsync(blogCategories);

            await _context.SaveChangesAsync();

            StatusMessage = "Tạo dữ liệu mẫu thành công!";

            return RedirectToAction(nameof(Index));
        }
    }
}