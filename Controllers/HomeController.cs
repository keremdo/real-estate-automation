using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cennet_Emlak.Models;
using Cennet_Emlak.Data.Abstract;

namespace Cennet_Emlak.Controllers;

public class HomeController : Controller
{
    private readonly IStartPageRepository _startRepo;
    private readonly IPortfolioRepository _portfolioRepo;
    private readonly IAboutRepository _aboutRepo;
    public HomeController(IStartPageRepository startRepo,IPortfolioRepository portfolioRepo,IAboutRepository aboutRepo)
    {
        _startRepo = startRepo;
        _portfolioRepo = portfolioRepo;
        _aboutRepo = aboutRepo;
    }
    public IActionResult Index()
    {
        var viewModel = new IndexViewModel{
            StartPages = _startRepo.Values.ToList(),
            Portfolios = _portfolioRepo.Values.ToList(),
            Abouts = _aboutRepo.Values.ToList()
        };
        return View(viewModel);
    }
  
}
