using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Database;
using MyBlog.Models.Contacts;

namespace MyBlog.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ContactController : Controller
    {
        private readonly MyBlogDbContext _context;

        public ContactController(MyBlogDbContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { set; get; }

        // GET: Contact
        [HttpGet("/admin/contact")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Contact/Details/5
        [HttpGet("/admin/contact/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactModel = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        // GET: Contact/Create
        [AllowAnonymous]
        [HttpGet("/contact/")]
        public IActionResult CreateContact()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost("/contact/")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContact([Bind("SenderName,Email,Message,PhoneNumber")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                contactModel.SendTime = DateTime.Now;
                
                _context.Add(contactModel);
                await _context.SaveChangesAsync();

                StatusMessage = "Gởi liên hệ thành công";

                return RedirectToAction("Index", "Home");
            }
            return View(contactModel);
        }

        // GET: Contact/Delete/5
        [HttpGet("/admin/contact/delete/{id}")]
       public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactModel = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        // POST: Contact/Delete/5
        [HttpPost("/admin/contact/delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactModel = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contactModel);
            await _context.SaveChangesAsync();

            StatusMessage = "Xóa liên hệ thành công!";
            return RedirectToAction("Index", "Home");
        }
    }
}
