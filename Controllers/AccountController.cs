using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Entities;
using Cennet_Emlak.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cennet_Emlak.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _appRole;
        private SignInManager<AppUser> _singInManager;
        public AccountController(UserManager<AppUser> userManager,RoleManager<AppRole> appRole,SignInManager<AppUser> singInManager)
        {
            _userManager = userManager;
            _appRole = appRole;
            _singInManager = singInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    await _singInManager.SignOutAsync();

                    var result = await _singInManager.PasswordSignInAsync(user,model.Password,true,false);
                    if(result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user,null);

                        return RedirectToAction("Index","Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("","yanlıs sifre");
                    }
                }
                else{
                    ModelState.AddModelError("","yanlis eposta");
                }
            }
            return View(model);
        }
    }
}