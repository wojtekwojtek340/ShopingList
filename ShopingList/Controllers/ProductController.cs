using Microsoft.AspNetCore.Mvc;
using ShopingList.DataAccess;
using ShopingList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> repository;
        public ProductController(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            var products = await repository.GetAll();
            return products;
        }

        [HttpPost]
        public async Task Post([FromBody] ProductAdd productAdd)
        {
            Product product = new Product { Description = productAdd.Description,  Name = productAdd.Name, Quantity = productAdd.Quantity, ProductsListId = productAdd.ProductsListId };
            await repository.Insert(product);
        }

        [HttpDelete]
        public async Task Delete([FromQuery] int id)
        {
            await repository.Delete(id);
        }

        public class ProductAdd
        {
            public string Name { get; set; } 
            public int Quantity { get; set; }
            public string Description { get; set; }
            public int ProductsListId { get; set; }
        }
    }
}
