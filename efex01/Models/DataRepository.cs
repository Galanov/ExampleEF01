using System;
using System.Collections.Generic;
using System.Linq;
using efex01.Models.Pages;
using Microsoft.EntityFrameworkCore;

namespace efex01.Models
{
    public class DataRepository:IRepository
    {
        //public DataRepository()
        //{
        //}

        //private List<Product> data = new List<Product>();
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;
        /*Методы ToArray() и ToList() из LINQ запускают выполнение запроса и выпускают массив
        или список, который содержит результаты. Они представляют собой обычную коллекцию 
        объектов в памяти, которая реализует только интерфейс IEnumerable<T>, что означает 
        необходимость изменения модели представления в представлении Index, применяемом 
        контроллером Home. Это также означает, что можно безпасно возвратиться к выполнению
         множества операций LINQ в представлении, не заботясь о том, как были получены данные.    
        */
        public IEnumerable<Product> Products => context.Products
            .Include(p=>p.Category).ToArray();

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

    public Product GetProduct(long key)=>context.Products
            .Include(p=>p.Category).First(p=>p.Id == key);

        public void UpdateProduct(Product product)
        {
            //Product p = GetProduct(product.Id);
            Product p = context.Products.Find(product.Id);
            p.Name = product.Name;
            //p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            p.CategoryId = product.CategoryId;
            //context.Products.Update(product);
            context.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            //context.Products.UpdateRange(products);
            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.Id));

            foreach (var databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public PagedList<Product> GetProducts(QueryOptions options)
        {
            return new PagedList<Product>(context.Products.Include(p => p.Category), options);
        }
    }
}
