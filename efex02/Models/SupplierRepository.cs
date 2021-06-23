using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace efex02.Models
{
    public interface ISupplierRepository
    {
        Supplier Get(long id);
        IEnumerable<Supplier> GetAll();
        void Create(Supplier newDataObject);
        void Update(Supplier changedDataObject);
        void Delete(long id);
    }

    public class SupplierRepository : ISupplierRepository
    {
        private EFDatabaseContext context;

        public SupplierRepository(EFDatabaseContext ctx) => context = ctx;

        public void Create(Supplier newDataObject)
        {
            context.Add(newDataObject);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.Remove(Get(id));
            context.SaveChanges();
        }

        public Supplier Get(long id)
        {
            return context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            /*
            //заполняет кэш EF объектами данных
            context.Products.Where(p => p.Supplier != null && p.Price > 50).Load();
            //EF автоматически проверит данные из первого запроса и будет использовать их для заполнения навигационных
            //св-в Supplier.Products подходящими объектами Product
            //такой процесс будет выполняться в случае применения одного и того же объекта контекста бд для выполнения 
            //множества запросов.
            return context.Suppliers;
            */
            /*
            //явная загрузка
            IEnumerable<Supplier> data = context.Suppliers.ToArray();
            foreach (var s in data)
            {
                //Reference(name) - используется для навигационных свойств, которые нацелены на одиночный объект
                //указанный либо как строка, либо с помощью лямбда-выражения для выбора свойства
                //Collection(name) - применяется для навигационных св-в, которые нацелены на коллекцию, указанную
                //либо как строка, либо с помощью лямбда-выражения для выбора свойства
                context.Entry(s).Collection(e => e.Products)
                    .Query()
                    .Where(p => p.Price > 50)
                    .Load();
            }
            return data;
            */
            return context.Suppliers.Include(s=>s.Products);

        }

        public void Update(Supplier changedDataObject)
        {
            context.Update(changedDataObject);
            context.SaveChanges();
        }
    }
}
