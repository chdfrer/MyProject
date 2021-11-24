using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Areas.Categories.Models;
using MyBlog.Database;
using MyBlog.Services.levelListServices;

namespace MyBlog.Areas.Categories.Controllers
{
    [Area("Categories")]
    [Route("/admin/category/[action]")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly MyBlogDbContext _context;
        private readonly CreateLevelList _createLevelList;

        public CategoryController(MyBlogDbContext context, CreateLevelList createLevelList)
        {
            _context = context;
            _createLevelList = createLevelList;
        }

        [HttpGet("/admin/category")]
        public IActionResult Index()
        {
            var listCategory = _createLevelList.CreateList(_context.Categories.ToList());
            ViewBag.totalitem = listCategory.Count();

            return View(listCategory);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listCategory = _createLevelList.CreateList(_context.Categories.ToList(), true, "--");

            ViewData["ParentCategoryId"] = new SelectList(listCategory, "Id", "Title");

            return View();
        }

        // POST: Categories/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,Slug,ParentCategoryId")] CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryModel.ParentCategoryId == -1) categoryModel.ParentCategoryId = null;

                _context.Add(categoryModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.Categories, "Id", "Title", categoryModel.ParentCategoryId);
            return View(categoryModel);
        }

        // GET: Categories/Category/Edit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories.FindAsync(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            var listCategory = _createLevelList.CreateList(_context.Categories.ToList(), true, "--");

            _createLevelList.RemoveChildren(categoryModel, listCategory);

            ViewData["ParentCategoryId"] = new SelectList(listCategory, "Id", "Title", categoryModel.ParentCategoryId);
            return View(categoryModel);
        }

        // POST: Categories/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Slug,ParentCategoryId")] CategoryModel categoryModel)
        {
            
            if (id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categoryModel.ParentCategoryId == -1) categoryModel.ParentCategoryId = null;

                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var listCategory = _createLevelList.CreateList(_context.Categories.ToList(), true, "--");

            _createLevelList.RemoveChildren(categoryModel, listCategory);

            ViewData["ParentCategoryId"] = new SelectList(listCategory, "Id", "Title", categoryModel.ParentCategoryId);

            return View(categoryModel);
        }

        // GET: Categories/Category/Delete/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: Categories/Category/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryModel = await _context.Categories
                .Include(c => c.CategoryChildren)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            foreach(var cCategory in categoryModel.CategoryChildren)
            {
                cCategory.ParentCategoryId = categoryModel.ParentCategoryId;
            }

            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
