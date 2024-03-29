﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using efex01.Models;
using efex01.Models.Pages;


namespace efex01.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository repository;

        public CategoriesController(ICategoryRepository repo) =>
            repository = repo;

        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetCategories(options));
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            repository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCategory(long id)
        {
            ViewBag.EditId = id;
            return View("Index", repository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            repository.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            repository.DeleteCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
