using BackendDev_Case1_Bogani.DTOs;

namespace BackendDev_Case1_Bogani.Services
{
    public interface ICategoryService
{
   Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);
}
}