using System;
using Microsoft.AspNetCore.Mvc;
using efex01.Models;

namespace efex01.Controllers
{
    public class HomeController:Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Products);

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
