
using BackendDev_Case1_Bogani.DTOs;
using BackendDev_Case1_Bogani.Data;
using BackendDev_Case1_Bogani.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendDev_Case1_Bogani.Services
{
public class CategoryService : ICategoryService
{
    private readonly ECommerceDbContext _context;

    public CategoryService(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .ToListAsync();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        categoryDto.Id = category.Id;
        return categoryDto;
    }

    public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            throw new KeyNotFoundException("Category not found.");

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            throw new KeyNotFoundException("Category not found.");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
}