using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex03.Models.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace efex03.Controllers
{
    public class HomeController : Controller
    {
        private ScaffoldContext context;

        public HomeController(ScaffoldContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return View(context.Shoes
                .Include(s=>s.Color)
                .Include(s=>s.SalesCampaigns)
                .Include(s=>s.ShoeCategoryJunction)
                .ThenInclude(junct => junct.Category)
                .Include(s=>s.Fitting));
        }
    }
}
