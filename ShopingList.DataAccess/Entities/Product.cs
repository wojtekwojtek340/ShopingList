using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingList.DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        public int ProductsListId { get; set; }
    }
}
