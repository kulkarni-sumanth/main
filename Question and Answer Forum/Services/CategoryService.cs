using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.DB;
using Dapper;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.Services
{
    public class CategoryService : ICategoryService
    {
        public IDapperContext Context { get; set; } 
        public CategoryService(IDapperContext context)
        {
            this.Context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            string query = "INSERT INTO Categories (Name, Description) VALUES(@Name, @Description)";
            using(var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, category);
            }
        }
        public async Task<CategoryModel> GetCategoryByIdAsync(Guid categoryId)
        {
            string query = "SELECT * FROM CategoryQuestionView WHERE Id = @categoryId";
            using (var connection = Context.CreateConnection())
            {
               CategoryModel category = await connection.QuerySingleOrDefaultAsync<CategoryModel>(query, new { categoryId });
               return category;
            }
        }

        public async Task<List<CategoryModel>> FilterCategoriesAsync(string filterBy)
        {
            string query = "SELECT * FROM CategoryQuestionView WHERE 1 = 1 ";
            if (filterBy == "popular")
            {
                query.Insert(7, " TOP 5 ");
                query += "ORDER BY NoOfQuestions DESC ";
            }

            using (var connection = Context.CreateConnection())
            {
                IEnumerable<CategoryModel> categories = await connection.QueryAsync<CategoryModel>(query);
                return categories.ToList();
            }
        }

        public async Task<List<CategoryModel>> SearchCategoriesByKeywordAsync(string filterBy, string keyword)
        {
            List<CategoryModel> categories = await FilterCategoriesAsync(filterBy);
            categories = categories.Where(category => category.Name.Contains(keyword) || category.Description.Contains(keyword)).ToList();
            return categories;
        }
    }
}