using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex02.Models;
using Microsoft.EntityFrameworkCore;

namespace efex02.Controllers
{
    public class One2OneController : Controller
    {
        private EFDatabaseContext context;
        public One2OneController(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Set<ContactDetails>().Include(cd => cd.Supplier));
        }

        public IActionResult Create()
        {
            return View("ContactEditor");
        }

        public IActionResult Edit(long id)
        {
            ViewBag.Suppliers = context.Suppliers.Include(s => s.Contact);
            return View("ContactEditor", context.Set<ContactDetails>()
                .Include(cd => cd.Supplier).First(cd => cd.Id == id));
            
        }

        [HttpPost]
        public IActionResult Update(ContactDetails details,
            long? targetSupplierId, long[] spares)
        {
            if (details.Id == 0)
            {
                context.Add<ContactDetails>(details);
            }
            else
            {
                context.Update<ContactDetails>(details);
                if (targetSupplierId.HasValue)
                {
                    if (spares.Contains(targetSupplierId.Value))
                    {
                        details.SupplierId = targetSupplierId.Value;
                    }
                    else
                    {
                        /*
                        //Пример для обновления один к одному
                        ContactDetails targetDetails = context.Set<ContactDetails>()
                            .FirstOrDefault(cd => cd.SupplierId == targetSupplierId);
                        targetDetails.SupplierId = details.Supplier.Id;
                        Supplier temp = new Supplier { Name = "temp" };
                        details.Supplier = temp;
                        context.SaveChanges();
                        temp.Contact = null;
                        details.SupplierId = targetSupplierId.Value;
                        context.Suppliers.Remove(temp);
                        */
                        ContactDetails targetDetails = context.Set<ContactDetails>()
                            .FirstOrDefault(cd => cd.SupplierId == targetSupplierId);
                        targetDetails.SupplierId = null;
                        details.SupplierId = targetSupplierId.Value;
                        context.SaveChanges();
                    }
                }
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
