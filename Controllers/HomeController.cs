using System.Diagnostics;
using Fut360.Data;
using Fut360.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fut360.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto _context;


        public HomeController(Contexto context)
        {
            _context = context;
  
        }

        // GET: Local
        public async Task<IActionResult> Index()
        {
            HomeModel home = new HomeModel();
            LocalModel locais = new LocalModel();

            HomeModel viewModel = new HomeModel
            {
                Home = home,
                Local = locais
            };

            return _context.LocalModel != null ?
                        View(await _context.LocalModel.ToListAsync()) :
                        Problem("Entity set 'Contexto.local'  is null.");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
