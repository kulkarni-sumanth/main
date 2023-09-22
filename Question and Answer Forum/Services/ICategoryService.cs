using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.Services
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(Category category);
        public Task<CategoryModel> GetCategoryByIdAsync(Guid categoryId);
        public Task<List<CategoryModel>> FilterCategoriesAsync(string filterBy);
        public Task<List<CategoryModel>> SearchCategoriesByKeywordAsync(string filterBy, string keyword);
    }
}