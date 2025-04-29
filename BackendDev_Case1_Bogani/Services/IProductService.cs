using System.Collections.Generic;
using System.Threading.Tasks;
using BackendDev_Case1_Bogani.DTOs;

namespace BackendDev_Case1_Bogani.Services
{
   public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(ProductDto productDto);
    Task UpdateProductAsync(int id, ProductDto productDto);
    Task DeleteProductAsync(int id);
}
}