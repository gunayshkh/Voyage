using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Voyage.Areas.Admin.Models.ViewModels;
using Voyage.DAL;
using Voyage.DATA.Constants;
using Voyage.Models.Entities;

namespace Voyage.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = nameof(RoleConstants.SuperAdmin) + ","
    // + nameof(RoleConstants.Moderator))]

    public class UserController : Controller
    {
        private readonly VoyageDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<User> userManager, VoyageDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _db.Users.ToListAsync();
            var usersList = new List<UserViewModel>();

            foreach (var user in users)
            {
                usersList.Add(new UserViewModel
                {
                    Id = user.Id,
                    Image = user.ImageURL,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                });
            }
            return View(usersList);

        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userViewModel = new ChangePasswordViewModel
            {
                Id = user.Id,
                Username = user.UserName
            };
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userViewModel = new ChangePasswordViewModel
            {
                Id = user.Id,
                Username = user.UserName
            };

            if (!ModelState.IsValid) return View(userViewModel);


            if (!await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                ModelState.AddModelError(nameof(ChangePasswordViewModel.OldPassword), "Old Password is not correct");
                return View();
            }

            var identityResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            return RedirectToAction(nameof(Index), "user", new { area = "Admin" });
        }

        [HttpPost]
        public async  Task<IActionResult> BlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            if (await _userManager.IsLockedOutAsync(user))
            {
                return BadRequest();
            }
            await _userManager.SetLockoutEnabledAsync(user, true);

            return View();
        }

        public async Task<IActionResult> AddRole(string id)
        {
            var user = await _db.Users.FindAsync(id);
            ViewBag.Roles = await _db.Roles.ToListAsync();

            if (user == null) return NotFound();
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName, 
                UserName = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0]
            };

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("AddRole")]

        public async Task<IActionResult> SubmitRole(string id, UserViewModel model)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return NotFound();
            var grantedRole = await _db.UserRoles.Where(g => g.UserId == id).FirstOrDefaultAsync();
            if (model.RoleId == null) return NotFound();
            if (model.RoleId == grantedRole.RoleId) return BadRequest();

            var existingRoles = await _userManager.GetRolesAsync(user);
            if (model.RoleId == "0") return NotFound();
            await _userManager.RemoveFromRolesAsync(user, existingRoles);
            IdentityRole role = await _db.Roles.FirstOrDefaultAsync(r => r.Id == id);

            await _userManager.AddToRoleAsync(user, role.Name);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }


    }
}

