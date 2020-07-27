using System;
using System.Collections.Generic;

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

        public IEnumerable<Product> Products => context.Products;

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }
    }
}
