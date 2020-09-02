using System;
using System.Collections.Generic;
using efex01.Models.Pages;

namespace efex01.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        PagedList<Product> GetProducts(QueryOptions options);

        void AddProduct(Product product);

        Product GetProduct(long key);

        void UpdateProduct(Product product);

        void UpdateAll(Product[] products);

        void Delete(Product product);
    }
}
