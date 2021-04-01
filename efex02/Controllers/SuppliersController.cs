using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex02.Models;
using Microsoft.EntityFrameworkCore;

namespace efex02.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository supplierRepository;
        private EFDatabaseContext dbContext;

        public SuppliersController(ISupplierRepository supplierRepo, EFDatabaseContext context)
        {
            dbContext = context;
            supplierRepository = supplierRepo;
        }

        public IActionResult Index()
        {
            ViewBag.SupplierEditId = TempData["SupplierEditId"];
            ViewBag.SupplierCreateId = TempData["SupplierCreateId"];
            ViewBag.SupplierRelationshipId = TempData["SupplierRelationshipId"];
            return View(supplierRepository.GetAll());
        }

        public IActionResult Edit(long id)
        {
            TempData["SupplierEditId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            supplierRepository.Update(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(long id)
        {
            TempData["SupplierCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Change(long id)
        {
            TempData["SupplierRelationshipId"] = id;
            return RedirectToAction(nameof(Index));
        }

        /*
        [HttpPost]
        public IActionResult Change(Supplier supplier)
        {
            IEnumerable<Product> changed = supplier.Products
                .Where(p => p.SupplierId != supplier.Id);
            if (changed.Count() > 0)
            {
                IEnumerable<Supplier> allSupliers = supplierRepository.GetAll().ToArray();
                Supplier currentSuplier = allSupliers.First(s => s.Id == supplier.Id);
                foreach (var p in changed)
                {
                    Supplier newSuplier = allSupliers.First(s => s.Id == p.SupplierId);
                    newSuplier.Products = newSuplier.Products.Append(currentSuplier.Products.First(op => op.Id == p.Id)).ToArray();
                    supplierRepository.Update(newSuplier);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        */
        /*
        [HttpPost]
        public IActionResult Change(Supplier supplier)
        {
            IEnumerable<Product> changed = supplier.Products
                .Where(p => p.SupplierId != supplier.Id);
            IEnumerable<long> targetSuppliersIds = changed
                .Select(p => p.SupplierId).Distinct();
            if (changed.Count() > 0)
            {
                IEnumerable<Supplier> targetSuppliers = dbContext.Suppliers
                    .Where(s => targetSuppliersIds.Contains(s.Id))
                    .AsNoTracking().ToArray();
                foreach (var p in changed)
                {
                    Supplier newSupplier = targetSuppliers.First(s => s.Id == p.SupplierId);
                    newSupplier.Products = newSupplier.Products == null
                        ? new Product[] { p }
                        : newSupplier.Products.Append(p).ToArray();
                }
                dbContext.Suppliers.UpdateRange(targetSuppliers);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }*/

        [HttpPost]
        public IActionResult Change(long id, Product[] products)
        {
            dbContext.Products.UpdateRange(products.Where(p => p.SupplierId != id));
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
