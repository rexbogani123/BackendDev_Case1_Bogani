using BackendDev_Case1_Bogani.Data;
using BackendDev_Case1_Bogani.DTOs;
using BackendDev_Case1_Bogani.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendDev_Case1_Bogani.Services
{
    public class ProductService : IProductService
{
    private readonly ECommerceDbContext _context;

    public ProductService(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        return await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToListAsync();
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).FirstOrDefaultAsync();

        return product;
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        productDto.Id = product.Id;
        return productDto;
    }

    public async Task UpdateProductAsync(int id, ProductDto productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }

        product.Name = productDto.Name;
        product.Price = productDto.Price;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
}