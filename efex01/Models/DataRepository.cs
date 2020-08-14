using System;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<Product> Products => context.Products.ToArray();

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public Product GetProduct(long key)=>context.Products.Find(key);

        public void UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.Name = product.Name;
            p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            //context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
