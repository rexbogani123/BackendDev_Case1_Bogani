using System;
using System.Collections.Generic;

namespace BackendDev_Case1_Bogani.DTOs
{
    public class ProductDto
    {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
