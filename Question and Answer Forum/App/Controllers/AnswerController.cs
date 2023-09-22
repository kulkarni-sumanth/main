using Question_and_Answer_Forum.Data;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Models;
using Question_and_Answer_Forum.Services;

namespace Question_and_Answer_Forum.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        public IAnswerService AnswerService { get; set; }
        public AnswerController(IAnswerService answerService)
        {
            AnswerService = answerService;
        }

        [HttpPost, Route("Like/{answerId}")]
        public async Task LikeAnAnswer(Guid answerId)
        {
            await AnswerService.LikeAnAnswerAsync(answerId);
        }

        [HttpPost, Route("DisLike/{answerId}")]
        public async Task DisLikeAnAnswer(Guid answerId)
        {
            await AnswerService.DisLikeAnAnswerAsync(answerId);
        }

        [HttpPost, Route("AddAnswer")]
        public async Task AddAnswer([FromBody] Answer answer)
        {
            await AnswerService.AddAnswerAsync(answer);
        }

        [HttpPost, Route("MarkAsBestSolution/{answerId}")]
        public async Task MarkAsBestSolution(Guid answerId)
        {
            await AnswerService.MarkAsBestSolutionAsync(answerId);
        }

        [HttpPost, Route("UnMarkBestSolution/{answerId}")]
        public async Task UnMarkBestSolution(Guid answerId)
        {
            await AnswerService.UnMarkBestSolutionAsync(answerId);
        }

        [HttpGet, Route("GetAnswersByQuestionId/{questionId}")]
        public async Task<ActionResult<List<AnswerModel>>> GetAnswersByQuestionId(Guid questionId)
        {
            List<AnswerModel> answers = await AnswerService.GetAnswersByQuestionIdAsync(questionId);
            return Ok(answers);
        }
    }
}