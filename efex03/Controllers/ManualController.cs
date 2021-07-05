using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex03.Models.Manual;

namespace efex03.Controllers
{
    public class ManualController : Controller
    {
        private ManualContext context;

        public ManualController(ManualContext ctx) => context = ctx;
        public IActionResult Index()
        {
            ViewBag.Styles = context.ShoeStyles;
            ViewBag.Widths = context.ShoeWidths;
            return View(context.Shoes);
        }
    }
}
