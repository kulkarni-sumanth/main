﻿using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.DB;
using Dapper;
using Question_and_Answer_Forum.Models;

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

        public async Task DisLikeAnAnswerAsync(Guid answerId)
        {
            string query = "UPDATE Answers SET Likes = Likes + 1 WHERE AnswerId = @answerId";
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