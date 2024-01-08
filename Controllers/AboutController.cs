using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cennet_Emlak.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutRepository _aboutRepo;
        public AboutController(IAboutRepository aboutRepo)
        {
            _aboutRepo = aboutRepo;
        }
        public IActionResult Index()
        {
            var abouts = _aboutRepo.Values.ToList();
            return View(abouts);
        }
        
        public IActionResult Update(int id)
        {
            var entity = _aboutRepo.Values.FirstOrDefault(m => m.AboutId == id);
            if(entity == null)
            {
               return NotFound();
            }
            return View(entity);
            
        }
        [HttpPost]
        public IActionResult Update(int id, About model)
        {
            if(id == model.AboutId)
            {
                _aboutRepo.Update(model);
                return RedirectToAction("Index","Home");
            }else{
                return View(model);
            }
        }
    }
}