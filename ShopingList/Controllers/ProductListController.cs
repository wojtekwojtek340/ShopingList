using Microsoft.AspNetCore.Mvc;
using ShopingList.DataAccess;
using ShopingList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopingList.Controllers.ProductController;

namespace ShopingList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductListController : ControllerBase
    {
        private readonly IRepository<ProductsList> repository;
        public ProductListController(IRepository<ProductsList> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductsList>> Get()
        {
            return await repository.GetAll();
        }

        [HttpPost]
        public async Task Post([FromBody] ProductListAdd productsListAdd)
        {
            ProductsList productsList = new ProductsList { Description = productsListAdd.Description, Name = productsListAdd.Name };

            productsList.ProductList = new List<Product>();

            foreach (var item in productsListAdd.ProductsList)
            {
                Product product = new Product { Name = item.Name, Description = item.Description, Quantity = item.Quantity };
                productsList.ProductList.Add(product);
            }


            await repository.Insert(productsList);
        }

        [HttpDelete]
        public async Task Delete([FromQuery] int id)
        {
            await repository.Delete(id);
        }

        public class ProductListAdd
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<ProductAdd> ProductsList { get; set; }
        }

    }
}
