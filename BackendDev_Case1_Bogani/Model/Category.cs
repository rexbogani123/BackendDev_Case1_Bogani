using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDev_Case1_Bogani.Model
{
    public class Category { 
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
     public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        
    }
}