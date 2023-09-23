using Question_and_Answer_Forum.Data;
using Dapper;
using Question_and_Answer_Forum.Models;
using Question_and_Answer_Forum.Services.DbServices;

namespace Question_and_Answer_Forum.Services
{
    public class AnswerService : IAnswerService
    {
        public IDapperContext Context { get; set; }
        public AnswerService(IDapperContext context) 
        {
            this.Context = context;
        }

        public async Task LikeAnAnswerAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET Likes = Likes + 1 WHERE AnswerId = @answerId";
            using(var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { answerId });
            }
        }

        public async Task RemoveLikeOfAnAnswerAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET Likes = Likes - 1 WHERE AnswerId = @answerId";
            using (var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { answerId });
            }
        }

        public async Task DisLikeAnAnswerAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET DisLikes = DisLikes + 1 WHERE AnswerId = @answerId";
            using (var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { answerId });
            }
        }

        public async Task RemoveDisLikeOfAnAnswerAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET DisLikes = DisLikes - 1 WHERE AnswerId = @answerId";
            using (var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { answerId });
            }
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            string query = "INSERT INTO Answers (Answer, QuestionId ,AnsweredBy) VALUES(@AnswerDescription, @QuestionId, @AnsweredBy)";
            using(var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, answer);
            }
        }
        public async Task<AnswerModel> GetAnswerByIdAsync(Guid answerId)
        {
            string query = "SELECT * UserAnswerView WHERE Id = @answerId";
            using (var connection = Context.CreateConnection())
            {
                var answer = await connection.QuerySingleOrDefaultAsync<AnswerModel>(query, new { answerId });
                return answer;
            }
        }

        public async Task<List<AnswerModel>> GetAnswersByQuestionIdAsync(Guid questionId)
        {
            string query = "SELECT * FROM UserAnswerView WHERE QuestionId = @questionId";
            using (var connection = Context.CreateConnection())
            {
                var answers = await connection.QueryAsync<AnswerModel>(query, new { questionId });
                return answers.ToList();
            }
        }

        public async Task MarkAsBestSolutionAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET IsBestSolution = 1 WHERE AnswerId = @answerId";
            using (var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { answerId });
            }
        }

        public async Task UnMarkBestSolutionAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET IsBestSolution = 0 WHERE AnswerId = @answerId";
            using (var connection = Context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { answerId });
            }
        }
    }
}