using MultiShop.Catalog.DTOs.CategoryDTOs;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    
    }
}
