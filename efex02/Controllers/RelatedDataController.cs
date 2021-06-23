using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex02.Models;

namespace efex02.Controllers
{
    public class RelatedDataController : Controller
    {

        private ISupplierRepository supplierRepo;
        private IGenericRepository<ContactDetails> detailsRepo;
        private IGenericRepository<ContactLocation> locsRepo;

        public RelatedDataController(ISupplierRepository sRepo,
            IGenericRepository<ContactDetails> dRepo,
            IGenericRepository<ContactLocation> lRepo)
        {
            supplierRepo = sRepo;
            detailsRepo = dRepo;
            locsRepo = lRepo;
        }
        public IActionResult Index()
        {
            return View(supplierRepo.GetAll());
        }

        public IActionResult Contacts() => View(detailsRepo.GetAll());
        public IActionResult Locations() => View(locsRepo.GetAll());
    }
}
