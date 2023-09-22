using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.DB;
using Dapper;
using Question_and_Answer_Forum.Models;

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

        public async Task<List<QuestionModel>> FilterQuestionsAsync(string categoryId, string filterBy, string timeSpan)
        {

            string query = "SELECT * From UserQuestionAnswerView WHERE 1 = 1";
            string signedUserId = "92350C83-F855-EE11-98EB-C4CBE1103F30";

            if (categoryId != "empty")
            {
                query += $" AND CategoryId='{categoryId}' ";
            }

            if (filterBy == "solved")
            {
                query += $" AND IsSolved={1} ";
            }
            else if (filterBy == "unsolved")
            {
                query += $" AND IsSolved={0} ";
            }
            else if (filterBy == "myquestions")
            {
                query += $" AND RaisedBy = '{signedUserId}' ";
            }
            else if (filterBy == "myparticipation")
            {
                query += $" AND (RaisedBy = '{signedUserId}' OR Id in (SELECT DISTINCT A.QuestionId FROM Answers A WHERE A.AnsweredBy = '{signedUserId}')) ";
            }
            else if (filterBy == "hot")
            {
                query.Insert(7, " TOP 5 ");
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

        public async Task<List<QuestionModel>> SearchQuestionsByKeywordAsync(string categoryId, string filterBy, string timeSpan, string keyword)
        {
            List<QuestionModel> questions = await FilterQuestionsAsync(categoryId, filterBy, timeSpan);
            questions = questions.Where(question => question.QuestionTitle.Contains(keyword) || question.Description.Contains(keyword)).ToList();
            return questions;
        }
    }
}