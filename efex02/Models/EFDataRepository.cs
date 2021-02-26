﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        }

        public void DeleteProduct(long id)
        {
            Console.WriteLine("DeleteProduct: " + id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts");
            return context.Products;
        }

        public Product GetProduct(long id)
        {
            Console.WriteLine("GetProduct: " + id);
            return new Product();
        }

        public IEnumerable<Product> GetProductsByPrice(decimal minPrice)
        {
            return context.Products.Where(p => p.Price >= minPrice).ToArray();
        }

        public void UpdateProduct(Product changedProduct)
        {
            Console.WriteLine("UpdateProduct: "
                + JsonConvert.SerializeObject(changedProduct));
        }
    }
}
