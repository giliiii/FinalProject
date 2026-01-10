//using BsdFinalProject.IRepositories;
//using BsdFinalProject.IServices;
using BsdFinalProject.DTOs;
using BsdFinalProject.IServices;
using BsdFinalProject.Models;
using BsdFinalProject.Repositories;

namespace BsdFinalProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _repository = new();
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ILogger<CategoryService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {   
            _logger.LogInformation("Fetching all categories");
            var categories = await _repository.GetAllCategories();
                if (categories == null) return Enumerable.Empty<CategoryDto>();
                return categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList();
        }
        

        public async Task<CategoryDto?> GetCategoryById(int id)
        {
            _logger.LogInformation("Fetching category with ID: {CategoryId}", id);
            var c = await _repository.GetCategoryById(id);
            if (c == null)
            {
                _logger.LogWarning("Category with ID: {CategoryId} not found", id);
                throw new Exception($"Category with id {id} not found.");
            }
            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
            };
        }
    }
}