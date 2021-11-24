// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MyBlog.Areas.Identity.Models.UserViewModels;
using MyBlog.Database;
using MyBlog.ExtendMethods;
using MyBlog.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyBlog.Areas.Identity.Controllers
{

    [Authorize(Policy = "Admin")]
    [Area("Identity")]
    [Route("/ManageUser/[action]")]
    public class UserController : Controller
    {

        private readonly ILogger<RoleController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MyBlogDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(ILogger<RoleController> logger, RoleManager<IdentityRole> roleManager, MyBlogDbContext context, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        //
        // GET: /ManageUser/Index
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "pageNumber")] int pageNumber)
        {
            var toPagingModel = new ToPagingModel()
            {
                TotalItem = await _context.Users.CountAsync(),
                CurrentPage = pageNumber,
                generateUrl = (pageNum) => Url.Action(nameof(Index), new { pageNumber = pageNum })
            };

            toPagingModel.listUserAndRoles = await _context.Users.OrderBy(u => u.UserName)
                                                            .Skip(toPagingModel.CountPages - 1)
                                                            .Take(toPagingModel.ItemPerPage)
                                                            .Select(u => new UserAndRole()
                                                            {
                                                                Id = u.Id,
                                                                UserName = u.UserName,
                                                            })
                                                            .ToListAsync();

            foreach (var userAndRole in toPagingModel.listUserAndRoles)
            {
                var roles = await _userManager.GetRolesAsync(userAndRole);
                userAndRole.RoleNames = string.Join(",", roles);
            } 
            
            return View(toPagingModel);
        } 

        // GET: /ManageUser/AddRole/id
        [HttpGet("{id}")]
        public async Task<IActionResult> AddRoleAsync(string id)
        {
            // public SelectList allRoles { get; set; }
            var model = new AddUserRoleModel();
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Không có user");
            }

            model.user = await _userManager.FindByIdAsync(id);

            if (model.user == null)
            {
                return NotFound($"Không thấy user, id = {id}.");
            }

            model.RoleNames = (await _userManager.GetRolesAsync(model.user)).ToArray<string>();

            List<string> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.allRoles = new SelectList(roleNames);

            await GetClaims(model);

            return View(model);
        }

        // GET: /ManageUser/AddRole/id
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleAsync(string id, [Bind("RoleNames")] AddUserRoleModel model)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Không có user");
            }

            model.user = await _userManager.FindByIdAsync(id);

            if (model.user == null)
            {
                return NotFound($"Không thấy user, id = {id}.");
            }
            await GetClaims(model);

            var OldRoleNames = (await _userManager.GetRolesAsync(model.user)).ToArray();

            List<string> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            ViewBag.allRoles = new SelectList(roleNames);

            if (model.RoleNames==null)
            {
                var resultDel = await _userManager.RemoveFromRolesAsync(model.user, OldRoleNames);
                if (!resultDel.Succeeded)
                {
                    ModelState.AddModelError(resultDel);
                    return View(model);
                }

                StatusMessage = $"Vừa cập nhật role cho user: {model.user.UserName}";

                return RedirectToAction(nameof(Index), new { StatusMessage });
            }

            var deleteRoles = OldRoleNames.Where(role => !model.RoleNames.Contains(role));
            var addRoles = model.RoleNames.Where(role => !OldRoleNames.Contains(role));

            var resultDelete = await _userManager.RemoveFromRolesAsync(model.user,deleteRoles);
            if (!resultDelete.Succeeded)
            {
                ModelState.AddModelError(resultDelete);
                return View(model);
            }
            
            var resultAdd = await _userManager.AddToRolesAsync(model.user,addRoles);
            if (!resultAdd.Succeeded)
            {
                ModelState.AddModelError(resultAdd);
                return View(model);
            }

            
            StatusMessage = $"Vừa cập nhật role cho user: {model.user.UserName}";

            return RedirectToAction(nameof(Index), new { StatusMessage });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SetPasswordAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Không có user");
            }

            var user = await _userManager.FindByIdAsync(id);
            ViewBag.user = ViewBag;

            if (user == null)
            {
                return NotFound($"Không thấy user, id = {id}.");
            }

            return View();
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPasswordAsync(string id, SetUserPasswordModel model)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Không có user");
            }

            var user = await _userManager.FindByIdAsync(id);
            ViewBag.user = ViewBag;

            if (user == null)
            {
                return NotFound($"Không thấy user, id = {id}.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
             
            await _userManager.RemovePasswordAsync(user);

            var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            StatusMessage = $"Vừa cập nhật mật khẩu cho user: {user.UserName}";

            return RedirectToAction(nameof(Index), new { StatusMessage });
        }        


        [HttpGet("{userid}")]
        public async Task<ActionResult> AddClaimAsync(string userid)
        {
            
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null) return NotFound("Không tìm thấy user");
            ViewBag.user = user;
            return View();
        }

        [HttpPost("{userid}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddClaimAsync(string userid, AddUserClaimModel model)
        {
            
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null) return NotFound("Không tìm thấy user");
            ViewBag.user = user;
            if (!ModelState.IsValid) return View(model);
            var claims = _context.UserClaims.Where(c => c.UserId == user.Id);

            if (claims.Any(c => c.ClaimType == model.ClaimType && c.ClaimValue == model.ClaimValue))
            {
                ModelState.AddModelError(string.Empty, "Đặc tính này đã có");
                return View(model);
            }

            await _userManager.AddClaimAsync(user, new Claim(model.ClaimType, model.ClaimValue));
            StatusMessage = "Đã thêm đặc tính cho user";
                        
            return RedirectToAction("AddRole", new {id = user.Id, StatusMessage});
        }        

        [HttpGet("{claimid}")]
        public async Task<IActionResult> EditClaim(int claimid)
        {
            var userclaim = _context.UserClaims.Where(c => c.Id == claimid).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userclaim.UserId);

            if (user == null) return NotFound("Không tìm thấy user");

            var model = new AddUserClaimModel()
            {
                ClaimType = userclaim.ClaimType,
                ClaimValue = userclaim.ClaimValue

            };
            ViewBag.user = user;
            ViewBag.userclaim = userclaim;
            return View("AddClaim", model);
        }
        [HttpPost("{claimid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClaim(int claimid, AddUserClaimModel model)
        {
            var userclaim = _context.UserClaims.Where(c => c.Id == claimid).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userclaim.UserId);
            if (user == null) return NotFound("Không tìm thấy user");

            if (!ModelState.IsValid) return View("AddClaim", model);

            if (_context.UserClaims.Any(c => c.UserId == user.Id 
                && c.ClaimType == model.ClaimType 
                && c.ClaimValue == model.ClaimValue 
                && c.Id != userclaim.Id))
                {
                    ModelState.AddModelError("Claim này đã có");
                    return View("AddClaim", model);
                }


            userclaim.ClaimType = model.ClaimType;
            userclaim.ClaimValue = model.ClaimValue;

            await _context.SaveChangesAsync();
            StatusMessage = "Bạn vừa cập nhật claim";
            

            ViewBag.user = user;
            ViewBag.userclaim = userclaim;
            return RedirectToAction("AddRole", new {id = user.Id, StatusMessage});
        }
        [HttpPost("{claimid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClaimAsync(int claimid)
        {
            var userclaim = _context.UserClaims.Where(c => c.Id == claimid).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userclaim.UserId);

            if (user == null) return NotFound("Không tìm thấy user");

            await _userManager.RemoveClaimAsync(user, new Claim(userclaim.ClaimType, userclaim.ClaimValue));

            StatusMessage = "Bạn đã xóa claim";
            
            return RedirectToAction("AddRole", new {id = user.Id, StatusMessage});
        }

        private async Task GetClaims(AddUserRoleModel model)
        {
            var listRoles = from role in _context.Roles
                join userrole in _context.UserRoles on role.Id equals userrole.RoleId
                where userrole.UserId == model.user.Id
                select role;

            var _claimsInRole  = from claim in _context.RoleClaims
                                 join role in listRoles on claim.RoleId  equals role.Id
                                 select claim;
            model.claimsInRole = await _claimsInRole.ToListAsync();


           model.claimsInUserClaim  = await (from claim in _context.UserClaims
            where claim.UserId == model.user.Id select claim).ToListAsync();

        }
    }
}
