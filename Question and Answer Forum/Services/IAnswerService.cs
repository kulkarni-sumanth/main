using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.Services
{
    public interface IAnswerService
    {
        public Task AddAnswerAsync(Answer answer);
        public Task LikeAnAnswerAsync(Guid answerId);
        public Task DisLikeAnAnswerAsync(Guid answerId);
        public Task MarkAsBestSolutionAsync(Guid answerId);
        public Task UnMarkBestSolutionAsync(Guid answerId);
        public Task<List<AnswerModel>> GetAnswersByQuestionIdAsync(Guid questionId);
    }
}