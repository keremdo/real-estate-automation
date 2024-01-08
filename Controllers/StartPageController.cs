using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cennet_Emlak.Controllers
{
    public class StartPageController : Controller
    {
        private readonly IStartPageRepository _startRepo;
        public StartPageController(IStartPageRepository startRepo)
        {
            _startRepo = startRepo;
        }

        public IActionResult Index()
        {
            var models = _startRepo.Values.ToList();
            return View(models);
        }

        public IActionResult Update(int id)
        {
            var model = _startRepo.Values.FirstOrDefault(m => m.StarPageId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id,StartPage model)
        {
            if(id == model.StarPageId)
            {
                _startRepo.Update(model);
                return RedirectToAction("Index","Home");
            }else{
                return View(model);
            }
        }
    }
}