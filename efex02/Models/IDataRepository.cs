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

        void CreateProduct(Product newProduct);

        void UpdateProduct(Product changedProduct);

        void DeleteProduct(long id);
    }
}
