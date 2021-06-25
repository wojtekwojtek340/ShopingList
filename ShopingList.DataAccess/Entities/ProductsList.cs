using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingList.DataAccess.Entities
{
    public class ProductsList : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
