using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efex01.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace efex01.Controllers
{
    public class SeedController : Controller
    {
        private DataContext context;

        public SeedController(DataContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.Count = context.Products.Count();
            return View(context.Products.Include(p => p.Category)
            .OrderBy(p => p.Id).Take(20));
        }

        [HttpPost]
        public IActionResult CreateSeedData(int count)
        {
            ClearData();
            if (count > 0)
            {
                context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
                context.Database.ExecuteSqlCommand("drop procedure if exists CreateSeedData");
                context.Database.ExecuteSqlCommand($@"
create procedure CreateSeedData
@rowCount decimal
as
begin 
set nocount on
declare @i int =1;
declare @catId bigint;
declare @catCount int = @rowCount/10;
declare @pprice decimal(5,2);
declare @rprice decimal(5,2);
begin transaction
while @i<@catCount
begin
insert into Categories (Name, Description)
values (concat('Category-',@i),
'Test Data Category');
set @catId = SCOPE_DENTITY();
declare @j int = 1;
while @j<=10
begin 
set @pprice = rand()*(500-5+1);
set @rprice = (Rand() * @pprice) + @pprice;
insert into Products (name, categoryid, purchasePrice, retailPrice)
values (concat('Product',@i,'-'@j), @catId, @pprice, @rprice)
set @j= @j+1;
end
set @i = @i+1;
end
commit
end");
                context.Database.BeginTransaction();
                context.Database.ExecuteSqlCommand($"exec CreateSeedData @RowCount = {count}");
                context.Database.CommitTransaction();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ClearData()
        {
            context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
            context.Database.BeginTransaction();
            context.Database.ExecuteSqlCommand("delete from orders");
            context.Database.ExecuteSqlCommand("delet from Categories");
            context.Database.CommitTransaction();
            return RedirectToAction(nameof(Index));
        }
    }

}
