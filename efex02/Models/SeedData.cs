using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efex02.Models
{
    public static class SeedData
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is EFDatabaseContext prodCtx && prodCtx.Products.Count() == 0)
                {
                    prodCtx.Products.AddRange(Products);
                }
                else if (context is EFCustomerContext custCtx && custCtx.Customers.Count() == 0)
                {
                    custCtx.Customers.AddRange(Customers);
                }
                context.SaveChanges();
            }
        }

        public static void ClearData(DbContext context)
        {
            if (context is EFDatabaseContext prodCtx && prodCtx.Products.Count() >0)
            {
                prodCtx.Products.RemoveRange(prodCtx.Products);
            }
            else if (context is EFCustomerContext custCtx && custCtx.Customers.Count() >0)
            {
                custCtx.Customers.RemoveRange(custCtx.Customers);
            }
            context.SaveChanges();
        }

        private static Product[] Products =
        {
            new Product
            {
                Name="Kayak",
                Category = "Watersports",
                Price = 275,
                
            },
            new Product
            {
                Name="Lafejacket",
                Category = "Watersports",
                Price = 48.95m,

            },
            new Product
            {
                Name="Soccer Ball",
                Category = "Soccer",
                Price = 19.50m,

            },
            new Product
            {
                Name="Corner Flags",
                Category = "Soccer",
                Price = 34.95m,

            },
            new Product
            {
                Name="Stadium",
                Category = "Soccer",
                Price = 79500,

            },
            new Product
            {
                Name="Thinking Cap",
                Category = "Chess",
                Price = 16,

            },
            new Product
            {
                Name="Unsteady Chair",
                Category = "Chess",
                Price = 29.95m,

            },
            new Product
            {
                Name="Human Chess Board",
                Category = "Chess",
                Price = 75,

            },
            new Product
            {
                Name="Bling-Bling King",
                Category = "Chess",
                Price = 1200,

            },
        };

        private static Customer[] Customers =
        {
            new Customer
            {
                Name = "Alice Smith",
                City = "New York",
                Country = "USA"
            },
            new Customer
            {
                Name = "Bob Jones",
                City = "Paris",
                Country = "France"
            },
            new Customer
            {
                Name = "Charlie Davies",
                City = "London",
                Country = "UK"
            },
        };
    }
}
