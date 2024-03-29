﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex02.Models;

namespace efex02.Controllers
{
    public class MigrationsController : Controller
    {
        private MigrationsManager manager;

        public MigrationsController(MigrationsManager mgr)
        {
            manager = mgr;
        }

        public IActionResult Index(string context)
        {
            ViewBag.Context = manager.ContextName = context ?? manager.ContextNames.First();
            return View(manager);
        }

        [HttpPost]
        public IActionResult Migrate(string context, string migration)
        {
            manager.ContextName = context;
            manager.Migrate(context, migration);
            return RedirectToAction(nameof(Index), new { context = context });
        }

        [HttpPost]
        public IActionResult Seed(string context)
        {
            manager.ContextName = context;
            SeedData.Seed(manager.Context);
            return RedirectToAction(nameof(Index), new { context = context });
        }

        [HttpPost]
        public IActionResult Clear(string context)
        {
            manager.ContextName = context;
            SeedData.ClearData(manager.Context);
            return RedirectToAction(nameof(Index), new { context = context });
        }
    }
}
