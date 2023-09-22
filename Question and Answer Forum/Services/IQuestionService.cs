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
        public Task<List<QuestionModel>> GetQuestionsAskedByUserAsync(Guid userId);
        public Task<List<QuestionModel>> GetQuestionsAnsweredByUserAsync(Guid userId);
        public Task<List<QuestionModel>> SearchQuestionsByKeywordAsync(Guid categoryId, string filterBy, string timeSpan, Guid signedUserId, string keyword);
        public Task<List<QuestionModel>> FilterQuestionsAsync(Guid categoryId, string filterBy, string timeSpan, Guid signedUserId);
    }
}