using Question_and_Answer_Forum.Data;
using Dapper;
using Question_and_Answer_Forum.Models;
using Question_and_Answer_Forum.Services.DbServices;

namespace Question_and_Answer_Forum.Services
{
    public class QuestionService : IQuestionService
    {
        public IDapperContext DapperContext { get; set; }
        public QuestionService(IDapperContext dapperContext)
        {
            this.DapperContext = dapperContext;
        }

        public async Task AddQuestionAsync(Question question)
        {
            string query = "INSERT INTO Questions (Question, Description, CategoryId, RaisedBy) VALUES(@QuestionTitle, @Description, @CategoryId, @RaisedBy);";
            using (var connection = DapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, question);
            }
        }
        public async Task<QuestionModel> GetQuestionByIdAsync(Guid questionId)
        {
            string query = "SELECT * FROM UserQuestionAnswerView WHERE Id = @questionId";
            using (var connection = DapperContext.CreateConnection())
            {
                QuestionModel question = await connection.QuerySingleOrDefaultAsync<QuestionModel>(query, new { questionId });
                return question;
            }
        }
        
        public async Task VoteAQuestionAsync(Guid questionId)
        {
            string query = "UPDATE Questions SET Votes = Votes + 1 WHERE QuestionId = @questionId";
            using (var connection = DapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { questionId });
            }
        }
        public async Task RemoveVoteForAQuestionAsync(Guid questionId)
        {
            string query = "UPDATE Questions SET Votes = Votes - 1 WHERE QuestionId = @questionId";
            using (var connection = DapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { questionId });
            }
        }
        public async Task IncrementViewsAsync(Guid questionId)
        {
            string query = "UPDATE Questions SET Views = Views + 1 WHERE QuestionId = @questionId";
            using (var connection = DapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { questionId });
            }
        }

        public async Task<List<QuestionModel>> GetQuestionsAskedByUserAsync(Guid userId)
        {
            string query = "SELECT * FROM UserQuestionAnswerView WHERE RaisedBy = @userId";
            using (var connection = DapperContext.CreateConnection())
            {
                IEnumerable<QuestionModel> questions = await connection.QueryAsync<QuestionModel>(query, new { userId });
                return questions.ToList();
            }
        }

        public async Task<List<QuestionModel>> GetQuestionsAnsweredByUserAsync(Guid userId)
        {
            string query = "SELECT * FROM UserQuestionAnswerView WHERE Id IN (SELECT DISTINCT A.QuestionId FROM Answers A WHERE A.AnsweredBy = @userId)";
            using (var connection = DapperContext.CreateConnection())
            {
                IEnumerable<QuestionModel> questions = await connection.QueryAsync<QuestionModel>(query, new { userId });
                return questions.ToList();
            }
        }

        public async Task<List<QuestionModel>> FilterQuestionsAsync(Guid categoryId, string filterBy, string timeSpan, Guid signedUserId)
        {

            string query = "SELECT * From UserQuestionAnswerView WHERE 1 = 1";

            if (categoryId != Guid.Empty)
            {
                query += $" AND CategoryId = '{categoryId}' ";
            }

            if (filterBy == "Solved")
            {
                query += $" AND IsSolved = {1} ";
            }
            else if (filterBy == "Unsolved")
            {
                query += $" AND IsSolved = {0} ";
            }
            else if (filterBy == "My Questions")
            {
                query += $" AND RaisedBy = '{signedUserId}' ";
            }
            else if (filterBy == "My Participation")
            {
                query += $" AND (RaisedBy = '{signedUserId}' OR Id in (SELECT DISTINCT A.QuestionId FROM Answers A WHERE A.AnsweredBy = '{signedUserId}')) ";
            }
            else if (filterBy == "Hot")
            {
                query = query.Insert(7, " TOP 5 ");
                query += " ORDER BY Views DESC ";
            }

            if (timeSpan == "Recent")
            {
                query += " AND DATEDIFF(DAY, CreatedAt, GETDATE()) < 2";
            }
            else if (timeSpan == "Last 10 Days")
            {
                query += " AND DATEDIFF(DAY, CreatedAt, GETDATE()) < 10";
            }
            else if (timeSpan == "Last 30 Days")
            {
                query += " AND DATEDIFF(DAY, CreatedAt, GETDATE()) < 30";
            }

            using (var connection = DapperContext.CreateConnection())
            {
                IEnumerable<QuestionModel> questions = await connection.QueryAsync<QuestionModel>(query);
                return questions.ToList();
            }
        }

        public async Task<List<QuestionModel>> SearchQuestionsByKeywordAsync(Guid categoryId, string filterBy, string timeSpan, Guid signedUserId, string keyword)
        {
            List<QuestionModel> questions = await FilterQuestionsAsync(categoryId, filterBy, timeSpan, signedUserId);
            questions = questions.Where(question => question.QuestionTitle.Contains(keyword) || question.Description.Contains(keyword)).ToList();
            return questions;
        }
    }
}