using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efex02.Models
{
    public interface IDataRepository
    {
        IEnumerable<Product> GetProductsByPrice(decimal minPrice);

        Product GetProduct(long id);
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null,
            bool includeRelated = true);

        void CreateProduct(Product newProduct);

        void UpdateProduct(Product changedProduct);

        void UpdateProduct(Product changedProduct, Product originalProduct = null);

        void DeleteProduct(long id);
    }
}
