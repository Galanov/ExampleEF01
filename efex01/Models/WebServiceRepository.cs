﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace efex01.Models
{
    public class WebServiceRepository : IWebServiceRepository
    {
        private DataContext context;

        public WebServiceRepository(DataContext ctx) => context = ctx;

        public void DeleteProduct(long id)
        {
            context.Products.Remove(new Product { Id = id });
            context.SaveChanges();
        }

        public object GetProduct(long id)
        {
            return context.Products
                .Select(p=> new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PurchasePrice = p.PurchasePrice,
                    RetailPrice = p.RetailPrice
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public object GetProducts(int skip, int take)
        {
            return context.Products.Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PurchasePrice = p.PurchasePrice,
                    RetailPrice = p.RetailPrice,
                    CategoryId = p.CategoryId,
                    Category = new
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description
                    }
                });
        }

        public object GetProductWithCategory(long id)
        {
            return context.Products
                .Include(p=>p.Category)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PurchasePrice = p.PurchasePrice,
                    RetailPrice = p.RetailPrice,
                    CategoryId = p.CategoryId,
                    Category = new
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description
                    }
                })
                .FirstOrDefault(p => p.Id == id);
        }

        public long StoreProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
