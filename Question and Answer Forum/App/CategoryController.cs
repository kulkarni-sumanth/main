using Question_and_Answer_Forum.Data;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Models;
using Question_and_Answer_Forum.Services;

namespace Question_and_Answer_Forum.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService CategoryService { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }

        [HttpPost,Route("AddCategory")]
        public async Task AddCategory([FromBody] Category category)
        {
            await CategoryService.AddCategoryAsync(category);
        }

        [HttpGet, Route("GetCategoryById/{categoryId}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(Guid categoryId)
        {
            CategoryModel category = await CategoryService.GetCategoryByIdAsync(categoryId);
            return Ok(category);
        }

        [HttpGet, Route("FilterCategories/{show}")]
        public async Task<ActionResult<List<CategoryModel>>> FilterCategories(string filterBy)
        {
            List<CategoryModel> categories = await CategoryService.FilterCategoriesAsync(filterBy);
            return Ok(categories);
        }

        [HttpGet, Route("SearchCategoriesByKeyword/{show}/{keyword}")]
        public async Task<ActionResult<List<CategoryModel>>> SearchCategoriesByKeyword(string filterBy, string keyword)
        {
            List<CategoryModel> categories = await CategoryService.SearchCategoriesByKeywordAsync(filterBy, keyword);
            return Ok(categories);
        }
    }
}