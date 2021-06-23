using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efex01.Models;

namespace efex01.Controllers
{
    [Route("api/products")]
    public class ProductValuesController : Controller
    {
        private IWebServiceRepository repository;

        public ProductValuesController(IWebServiceRepository repo)
        {
            repository = repo;
        }
        
        [HttpGet("{id}")]
        public object GetProduct(long id)
        {
            return repository.GetProduct(id) ?? NotFound();
        }

        [HttpGet]
        public object Products(int skip, int take)
        {
            return repository.GetProducts(skip, take);
        }

        [HttpPost]
        public long StoreProduct([FromBody] Product product)
        {
            return repository.StoreProduct(product);
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            repository.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            repository.DeleteProduct(id);
        }
    }
}
