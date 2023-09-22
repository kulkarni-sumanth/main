using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.Services
{
    public interface IQuestionService
    {
        public Task AddQuestionAsync(Question question);
        public Task<QuestionModel> GetQuestionByIdAsync(Guid questionId);
        public Task VoteAQuestionAsync(Guid questionId);
        public Task RemoveVoteForAQuestionAsync(Guid questionId);
        public Task IncrementViewsAsync(Guid questionId);
        public Task<List<QuestionModel>> SearchQuestionsByKeywordAsync(string categoryId, string filterBy, string timeSpan, string keyword);
        public Task<List<QuestionModel>> FilterQuestionsAsync(string categoryId, string filterBy, string sortBy);
    }
}