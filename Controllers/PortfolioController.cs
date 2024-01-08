using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Data.Concrete.EfCore;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cennet_Emlak.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioRepository _portfolioRepo;
        private readonly ISalesStateRepository _salesRepo;
        public PortfolioController(IPortfolioRepository portfolioRepo,ISalesStateRepository salesRepo)
        {
            _portfolioRepo = portfolioRepo;
            _salesRepo = salesRepo;
            
        }
        public IActionResult Index()
        {
            var models = _portfolioRepo.Values.ToList();
            return View(models);
        }

        public IActionResult Details(int id)
        {
            var model = _portfolioRepo.Values.FirstOrDefault(m=>m.PortfolioId == id);
            if(model == null){
                return NotFound();
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = _portfolioRepo.Values.FirstOrDefault(m => m.PortfolioId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id,Portfolio model)
        {
            if(id == model.PortfolioId)
            {
                _portfolioRepo.Delete(id);
                return RedirectToAction("Index","Portfolio");
            }else{
                return View(model);
            }
        }
        public IActionResult Create()
        {
            ViewBag.Sales = new SelectList(_salesRepo.SalesStates.ToList(),"SalesStateId","Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Portfolio model, IFormFile ImageUrl)
        {
            var extension = Path.GetExtension(ImageUrl.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/AdminLayoutx/img2",randomFileName);

            if(model != null)
            {
                using(var stream = new FileStream(path,FileMode.Create))
                {
                   await ImageUrl.CopyToAsync(stream);
                }
                model.ImageUrl = randomFileName;
                _portfolioRepo.Create(model);
                return RedirectToAction("Index","Portfolio");
            }
            return View(model);
        }

        public IActionResult Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = _portfolioRepo.Values.FirstOrDefault(m => m.PortfolioId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,Portfolio model,IFormFile? ImageUrl)
        {
            if(id!= model.PortfolioId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                if(ImageUrl != null)
                {
                    var extension = Path.GetExtension(ImageUrl.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/AdminLayoutx/img2",randomFileName);
                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                    }
                    model.ImageUrl = randomFileName;
                }
                _portfolioRepo.Update(model);
                return RedirectToAction("Index","Portfolio");
            }
            return View(model);
        }
    }
}