using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace efex02.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;

        public EFDataRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }

        public void CreateProduct(Product newProduct)
        {
            Console.WriteLine("CreateProduct: "
                + JsonConvert.SerializeObject(newProduct));
            newProduct.Id = 0;
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            Console.WriteLine("DeleteProduct: " + id);
            Product p = context.Products.Find(id);
            context.Products.Remove(p);
            //context.Products.Remove(new Product { Id = id });
            if (p.Supplier != null)
            {
                context.Remove<Supplier>(p.Supplier);
            }
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts");
            return context.Products.Include(p=>p.Supplier)
               ;
        }

        public IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null,
            bool includeRelated = true)
        {
            IQueryable<Product> data = context.Products;
            if (category != null)
            {
                data = data.Where(p => p.Category == category);
            }
            if (price != null)
            {
                data = data.Where(p => p.Price >= price);
            }
            if (includeRelated)
            {
                data = data.Include(p => p.Supplier);
            }
            return data;
        }

        public Product GetProduct(long id)
        {
            Console.WriteLine("GetProduct: " + id);
            return context.Products.Include(p =>p.Supplier)
                .ThenInclude(s => s.Contact)
                .ThenInclude(c => c.Location)
                .First(p=>p.Id == id);
        }

        public IEnumerable<Product> GetProductsByPrice(decimal minPrice)
        {
            return context.Products.Where(p => p.Price >= minPrice).ToArray();
        }

        public void UpdateProduct(Product changedProduct)
        {
            Console.WriteLine("UpdateProduct: "
                + JsonConvert.SerializeObject(changedProduct));
            //первый вариант
            //context.Products.Update(changedProduct);
            //второй вариант
            Product originalProduct = context.Products.Find(changedProduct.Id);
            originalProduct.Name = changedProduct.Name;
            originalProduct.Category = changedProduct.Category;
            originalProduct.Price = changedProduct.Price;
            originalProduct.Supplier.Name = changedProduct.Supplier.Name;
            originalProduct.Supplier.City = changedProduct.Supplier.City;
            originalProduct.Supplier.State = changedProduct.Supplier.State;

            EntityEntry entry = context.Entry(originalProduct);
            Console.WriteLine($"Entity State: {entry.State}");
            foreach (var p_name in new string[] { "Name", "Category", "Price" })
            {
                Console.WriteLine($"{p_name} - old: " +
                    $"{entry.OriginalValues[p_name]}, " +
                    $"New: {entry.CurrentValues[p_name]}");
            }
            context.SaveChanges();
        }

        public void UpdateProduct(Product changedProduct, Product originalProduct = null)
        {
            if (originalProduct == null)
            {
                originalProduct = context.Products.Find(changedProduct.Id);
            }
            else
            {
                context.Products.Attach(originalProduct);
            }
            originalProduct.Name = changedProduct.Name;
            originalProduct.Category = changedProduct.Category;
            originalProduct.Price = changedProduct.Price;
            context.SaveChanges();
        }
    }
}
