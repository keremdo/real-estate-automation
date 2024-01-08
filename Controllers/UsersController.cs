using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Entities;
using Cennet_Emlak.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cennet_Emlak.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _appRole;
        public UsersController(UserManager<AppUser> userManager,RoleManager<AppRole> appRole)
        {
            _userManager = userManager;
            _appRole = appRole;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser{UserName = model.Email,Email = model.Email, Fullname = model.Fullname};

                IdentityResult result =  await _userManager.CreateAsync(user,model.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Users");
                }
                foreach(IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("",err.Description);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                ViewBag.Roles = await _appRole.Roles.Select(i => i.Name).ToListAsync();
                return View(new EditViewModel {
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Email = user.Email,
                    SelectedRoles = await _userManager.GetRolesAsync(user)
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,EditViewModel model)
        {
            if(id != model.Id)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if(user != null)
                {
                    user.Email = model.Email;
                    user.Fullname = model.Fullname!;
                    var result =await _userManager.UpdateAsync(user);

                    if(result.Succeeded && !string.IsNullOrEmpty(model.Password))
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user,model.Password);
                    }
                    if(result.Succeeded)
                    {   
                        return RedirectToAction("Index");
                    }
                    foreach(IdentityError err in result.Errors)
                    {
                        ModelState.AddModelError("",err.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}