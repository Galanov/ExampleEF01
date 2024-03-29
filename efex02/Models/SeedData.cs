﻿using Microsoft.EntityFrameworkCore;
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
                    prodCtx.Set<Shipment>().AddRange(Shipments);
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
                prodCtx.Set<Shipment>().RemoveRange(prodCtx.Set<Shipment>());
            }
            else if (context is EFCustomerContext custCtx && custCtx.Customers.Count() >0)
            {
                custCtx.Customers.RemoveRange(custCtx.Customers);
            }
            context.SaveChanges();
        }

        public static Shipment[] Shipments
        {
            get
            {
                return new Shipment[]
                {
                    new Shipment{ ShipperName = "Express Co", StartCity = "New York", EndCity = "San Jose"},
                    new Shipment{ ShipperName = "Air Express", StartCity = "Miami", EndCity = "Seatle"},
                    new Shipment{ ShipperName = "Tortoise Shipping", StartCity = "Boston", EndCity = "Chicago"},
                };
            }
        }

        private static Product[] Products
        {
            get
            {
                Product[] products = new Product[] {
                    new Product
                    {
                        Name = "Kayak",
                        Category = "Watersports",
                        Price = 275,

                    },
                    new Product
                    {
                        Name = "Lafejacket",
                        Category = "Watersports",
                        Price = 48.95m,

                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Category = "Soccer",
                        Price = 19.50m,

                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Category = "Soccer",
                        Price = 34.95m,

                    },
                    new Product
                    {
                        Name = "Stadium",
                        Category = "Soccer",
                        Price = 79500,

                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Category = "Chess",
                        Price = 16,

                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Category = "Chess",
                        Price = 29.95m,

                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Category = "Chess",
                        Price = 75,

                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Category = "Chess",
                        Price = 1200,

                    },
                };
                ContactLocation hq = new ContactLocation
                {
                    LocationName = "Corporate HQ",
                    Address = "200 Acme Way"
                };

                ContactDetails bob = new ContactDetails
                {
                    Name = "Bob Smith",
                    Phone = "555-107-1234",
                    Location = hq
                };


                Supplier acme = new Supplier
                {
                    Name = "Acme Co",
                    City = "New York",
                    State = "WA",
                    Contact = bob
                };

                Supplier s1 = new Supplier
                {
                    Name = "Surf Dudes",
                    City = "San Jose",
                    State = "CA"
                };

                Supplier s2 = new Supplier
                {
                    Name = "Chess Kings",
                    City = "Seatle",
                    State = "WA"
                };
                
                foreach (var p in products)
                {
                    if (p == products[0])
                    {
                        p.Supplier = s1;
                    }
                    else if (p.Category == "Chess")
                    {
                        p.Supplier = s2;
                    }
                    else
                    {
                        p.Supplier = acme;
                    }
                    
                }
                return products;
            }
        }

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
