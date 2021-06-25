using Microsoft.EntityFrameworkCore;
using ShopingList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingList.DataAccess
{
    public class ShopingListContext : DbContext
    {
        public ShopingListContext(DbContextOptions<ShopingListContext> opt) : base(opt) { }        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsList> ProductsLists { get; set; }
    }
}
