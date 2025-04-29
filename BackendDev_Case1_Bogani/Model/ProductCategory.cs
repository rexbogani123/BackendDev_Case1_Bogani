using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDev_Case1_Bogani.Model
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();

        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
    }
}