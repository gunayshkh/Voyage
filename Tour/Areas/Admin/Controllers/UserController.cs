//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Voyage.Areas.Admin.Models.ViewModels;
//using Voyage.DAL;
//using Voyage.Migrations;

//namespace Voyage.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class UserController : Controller
//    {
//        private readonly VoyageDbContext _db;
//        private readonly UserManager<User> _userManager;
//        public UserController(UserManager<User> userManager, VoyageDbContext db)
//        {
//            _userManager = userManager;
//            _db = db;
//        }
//        public async Task<IActionResult> Index(int? page)
//        {
//            List<UserViewModel> usersVM = new List<UserViewModel>();
//            List<User> users;
//            ViewBag.PageCount = Math.Ceiling((decimal)_db.Users.Count() / 5);
//            ViewBag.Page = page;
//            if (page == null)
//            {
//                users = _db.Users.OrderByDescending(p => p.Id).Take(5).ToList();
//            }
//            else
//            {
//                users = _userManager.Users.OrderByDescending(p => p.Id).Skip(((int)page - 1) * 5).Take(5).ToList();
//            }

//            foreach (User user in users)
//            {
//                UserViewModel userVM = new UserViewModel
//                {
//                    Id = user.,
//                    FullName = user.FullName,
//                    UserName = user.UserName,
//                    Email = user.Email,
//                    Role = (await _userManager.GetRolesAsync(user))[0],
//                    IsActivated = user.IsActivated,
//                    CompanyName = user.CompanyName,
//                    Image = user.Image,
//                    JobTitle = user.JobTitle,
//                    JobType = user.JobType,
//                    ExpectedSalary = user.ExpectedSalary,
//                    Location = user.Location
//                };
//                usersVM.Add(userVM);
//            }

//            return View(usersVM);
//        }

//        //public async Task<IActionResult> Active(string id, bool IsActivated)
//        //{
//        //    if (id == null) return NotFound();
//        //    User user = await _userManager.FindByIdAsync(id);
//        //    if (user == null) return NotFound();
//        //    user.IsActivated = IsActivated;
//        //    await _db.SaveChangesAsync();
//        //    return RedirectToAction(nameof(Index));
//        //}

//        //public async Task<IActionResult> Disable(string id, bool IsActivated)
//        //{
//        //    if (id == null) return NotFound();
//        //    User user = await _userManager.FindByIdAsync(id);
//        //    if (user == null) return NotFound();
//        //    user.IsActivated = !IsActivated;
//        //    await _db.SaveChangesAsync();
//        //    return RedirectToAction(nameof(Index));
//        //}

//        //public async Task<IActionResult> ChangeRole(string id)
//        //{
//        //    if (id == null) return NotFound();
//        //    User user = await _userManager.FindByIdAsync(id);
//        //    if (user == null) return NotFound();
//        //    UserViewModel userVM = new UserViewModel
//        //    {
//        //        Id = user.Id,
//        //        UserName = user.UserName,
//        //        FullName = user.FullName,
//        //        Role = (await _userManager.GetRolesAsync(user))[0],
//        //        IsActivated = user.IsActivated,
//        //        Roles = new List<string> { "Admin", "Moderator", "Employer", "Seeker" }
//        //    };
//        //    return View(userVM);
//        //}
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> ChangeRole(string id, UserViewModel userVM, string Role)
//        //{
//        //    if (Role == null) return NotFound();
//        //    if (id == null) return NotFound();
//        //    User user = await _userManager.FindByIdAsync(id);
//        //    if (user == null) return NotFound();
//        //    string oldRole = (await _userManager.GetRolesAsync(user))[0];
//        //    await _userManager.RemoveFromRoleAsync(user, oldRole);
//        //    await _userManager.AddToRoleAsync(user, Role);
//        //    return RedirectToAction(nameof(Index));
//        //}

//        //public async Task<IActionResult> ChangePassword(string id)
//        //{
//        //    if (id == null) return NotFound();
//        //    User user = await _userManager.FindByIdAsync(id);
//        //    if (user == null) return NotFound();
//        //    return View(user);
//        //}
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> ChangePassword(string id, string Password)
//        //{
//        //    if (id == null) return NotFound();
//        //    User user = await _userManager.FindByIdAsync(id);
//        //    if (user == null) return NotFound();
//        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
//        //    IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, Password);
//        //    if (!identityResult.Succeeded)
//        //    {
//        //        foreach (var error in identityResult.Errors)
//        //        {
//        //            ModelState.AddModelError("", error.Description);
//        //        }
//        //        return View();
//        //    }
//        //    return RedirectToAction(nameof(Index));
//        //}

//        //public async Task<IActionResult> DeleteUser(string id)
//        //{
//        //    if (id == null) return NotFound();
//        //    User user = await _db.Users.FindAsync(id);
//        //    if (user == null) return NotFound();
//        //    return View(user);
//        //}

   


//    }
//}
//}
