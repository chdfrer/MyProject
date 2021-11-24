using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyBlog.Areas.Blog.Models;
using MyBlog.Areas.Categories.Models;
using MyBlog.Database;
using MyBlog.Models;
using MyBlog.Models.UserModels;
using MyBlog.Services.levelListServices;
using MyBlog.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas_Blog
{
    [Authorize]
    [Area("Blog")]
    [Route("/blog/[action]")]
    public class BlogController : Controller
    {
        private readonly MyBlogDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly CreateLevelList _createLevelList;

        public BlogController(MyBlogDbContext context, UserManager<AppUser> userManager, CreateLevelList createLevelList)
        {
            _context = context;
            _userManager = userManager;
            _createLevelList = createLevelList;
        }

        // GET: Blog
        [AllowAnonymous]
        [Route("/blog/{pageNumber?}")]
        public async Task<IActionResult> Index([FromQuery(Name = "pageNumber")] int pageNumber)
        {
            //Check login
            bool isLogin = false;
            var user = await _userManager.GetUserAsync(User);
            if (user != null) isLogin = true;
            ViewBag.isLogin = isLogin;

            //Prepare model for paging
            var pagingModel = new PagingModel()
            {
                CurrentPage = pageNumber,
                TotalItem = await _context.Blogs.CountAsync(),
                generateUrl = (pageNum) => Url.Action(nameof(Index), new { pageNumber = pageNum })
            };
            ViewData["pageModel"] = pagingModel;

            //Prepare model for view
            var blogList = await _context.Blogs.Where(b=>b.Published==true).OrderBy(b => b.Title)
                            .Skip((pagingModel.CurrentPage - 1) * pagingModel.ItemPerPage)
                            .Take(pagingModel.ItemPerPage)
                            .Include(b => b.Author)
                            .Include(b => b.BlogCategory).ThenInclude(bc => bc.Category)
                            .ToListAsync();

            return View(blogList);
        }

        [Route("{page?}")]
        public async Task<IActionResult> PrivateBlog([FromQuery(Name = "pageNumber")] int pageNumber)
        {
            var author = await _userManager.GetUserAsync(User);

            var pagingModel = new PagingModel()
            {
                CurrentPage = pageNumber,
                TotalItem = await _context.Blogs.Where(b => b.Author == author).CountAsync(),
                generateUrl = (pageNum) => Url.Action(nameof(Index), new { pageNumber = pageNum })
            };
            ViewData["pageModel"] = pagingModel;



            var blogList = await _context.Blogs.OrderBy(b => b.Title)
                        .Where(b => b.Author == author)
                        .Skip((pagingModel.CurrentPage - 1) * pagingModel.ItemPerPage)
                        .Take(pagingModel.ItemPerPage)
                        .Include(b => b.Author)
                        .Include(b => b.BlogCategory).ThenInclude(bc => bc.Category)
                        .ToListAsync();

            return View(blogList);
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.Blogs
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blogModel == null)
            {
                return NotFound();
            }

            return View(blogModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ReadAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.Blogs
                .Where(b=>b.Published==true)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blogModel == null)
            {
                return NotFound();
            }

            return View(blogModel);
        }

        // GET: Blog/Create
        public async Task<IActionResult> Create()
        {
            var author = await _userManager.GetUserAsync(User);
            ViewData["author"] = author.Name != null ? author.Name : author.UserName;

            // Danh mục chọn để đăng bài Post
            var categories = await _context.Categories.ToListAsync();

            ViewData["categories"] = new MultiSelectList(_createLevelList.CreateList(categories, false, "---"), "Id", "Title");

            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Slug,Content,Published,CategoryIds")] CreateBlogModel createBlogModel)
        {
            var categories = await _context.Categories.ToListAsync();
            ViewData["categories"] = new MultiSelectList(_createLevelList.CreateList(categories, false, "---"), "Id", "Title");

            var author = await _userManager.GetUserAsync(User);
            ViewData["author"] = author.Name != null ? author.Name : author.UserName;

            // Phát sinh Slug theo Title nếu Slug không được nhập
            if (createBlogModel.Slug == null)
            {
                createBlogModel.Slug = AppUtilities.GenerateSlug(createBlogModel.Title);
                ModelState.SetModelValue("Slug", new ValueProviderResult(createBlogModel.Slug));
                // Thiết lập và kiểm tra lại Model
                ModelState.Clear();
                TryValidateModel(createBlogModel);
            }
            if (ModelState.IsValid)
            {
                if (await _context.Blogs.AnyAsync(b => b.Slug == createBlogModel.Slug))
                {
                    ModelState.AddModelError("Slug", "Url đã tồn tại");
                    return View(createBlogModel);
                }

                createBlogModel.Author = await _userManager.GetUserAsync(User);
                createBlogModel.DateCreated = createBlogModel.DateUpdated = DateTime.Now;

                foreach (int categoryIds in createBlogModel.CategoryIds)
                {
                    var category = _context.Categories.FirstOrDefault(c => c.Id == categoryIds);

                    _context.BlogCategory.Add(new BlogCategory()
                    {
                        BlogId = createBlogModel.BlogId,
                        CategoryId = categoryIds,
                        Category = category,
                        Blog = createBlogModel
                    });
                }

                _context.Add(createBlogModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PrivateBlog));
            }

            return View(createBlogModel);
        }

        // GET: Blog/Edit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createBlogModel = await _context.Blogs.Where(b => b.BlogId == id)
                                                .Include(b => b.BlogCategory)
                                                .ThenInclude(bc => bc.Category)
                                                .Select(b => new CreateBlogModel()
                                                {
                                                    BlogId = b.BlogId,
                                                    Title = b.Title,
                                                    Description = b.Description,
                                                    Slug = b.Slug,
                                                    Content = b.Content,
                                                    Published = b.Published,
                                                    BlogCategory = b.BlogCategory,
                                                    AuthorId = b.AuthorId,
                                                    DateCreated = b.DateCreated
                                                })
                                                .FirstOrDefaultAsync();

            if (createBlogModel == null)
            {
                return NotFound();
            }
            if (await IsntAuthorAsync(createBlogModel))
            {
                return RedirectToRoute("accessdenied");
            }

            //Create selectedValue for MultiSelectList
            var selectedValue = new List<int>();
            foreach (var blogCate in createBlogModel.BlogCategory)
            {
                selectedValue.Add(blogCate.CategoryId);
            }
            //Prepare list Item for MultiSelectList
            var categories = await _context.Categories.ToListAsync();

            ViewData["categories"] = new MultiSelectList(_createLevelList.CreateList(categories, false, "---"), "Id", "Title", selectedValue);

            return View(createBlogModel);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Title,Description,Slug,Content,Published,DateCreated,CategoryIds,AuthorId")] CreateBlogModel createBlogModel)
        {
            if (id != createBlogModel.BlogId)
            {
                return NotFound();
            }
            
            if (await IsntAuthorAsync(createBlogModel))
            {
                return RedirectToRoute("accessdenied");
            }

            //Prepare list Item for MultiSelectList
            var categories = await _context.Categories.ToListAsync();

            ViewData["categories"] = new MultiSelectList(_createLevelList.CreateList(categories, false, "---"), "Id", "Title", createBlogModel.CategoryIds);

            if (ModelState.IsValid)
            {
                if (await _context.Blogs.AnyAsync(b => b.Slug == createBlogModel.Slug
                                                            && b.BlogId != createBlogModel.BlogId))
                {
                    ModelState.AddModelError("Slug", "Url đã tồn tại");
                    return View(createBlogModel);
                }

                try
                {
                    createBlogModel.DateUpdated = DateTime.Now;
                    _context.Update(createBlogModel);

                    var blog = _context.Blogs.Where(b => b.BlogId == id).Include(b => b.BlogCategory).FirstOrDefault();

                    var oldCategories = blog.BlogCategory;

                    //Update Categories
                    foreach(var blogCategory in oldCategories)
                    {
                        if (!createBlogModel.CategoryIds.Contains(blogCategory.CategoryId))
                        {
                            _context.Remove(blogCategory);
                        }
                    }
                    foreach(var cateId in createBlogModel.CategoryIds)
                    {
                        if (oldCategories.Find(bc => bc.CategoryId == cateId) == null)
                        {
                            _context.Add(new BlogCategory() { BlogId = id, CategoryId = cateId });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogModelExists(createBlogModel.BlogId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PrivateBlog));
            }

            return View(createBlogModel);
        }

        // GET: Blog/Delete/5
        [Route("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.Blogs
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BlogId == id);

            if (blogModel == null)
            {
                return NotFound();
            }
            if (await IsntAuthorAsync(blogModel))
            {
                return RedirectToRoute("accessdenied");
            }

            return View(blogModel);
        }

        // POST: Blog/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogModel = await _context.Blogs.FindAsync(id);

            if (blogModel == null)
            {
                return NotFound();
            }
            if (await IsntAuthorAsync(blogModel))
            {
                return RedirectToRoute("accessdenied");
            }

            _context.Blogs.Remove(blogModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(PrivateBlog));
        }

        private bool BlogModelExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }

        private async Task<bool> IsntAuthorAsync(BlogModel blogModel)
        {
            var user = await _userManager.GetUserAsync(User);

            return blogModel.AuthorId != user.Id;
        }

    }
}
