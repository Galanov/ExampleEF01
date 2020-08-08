using System;
using Microsoft.AspNetCore.Mvc;
using efex01.Models;
using System.Linq;

namespace efex01.Controllers
{
    public class HomeController:Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() {
            //System.Console.Clear();
           return View(repository.Products as IQueryable<Product>) ;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
