using Question_and_Answer_Forum.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Models;
using Question_and_Answer_Forum.Services;

namespace Question_and_Answer_Forum.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public IQuestionService QuestionService { get; set; }
        public QuestionController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }

        [HttpPost, Route("AddQuestion")]
        public async Task AddQuestion([FromBody] Question question)
        {
            await QuestionService.AddQuestionAsync(question);
            Ok();
        }

        [HttpGet, Route("GetQuestionById/{questionId}")]
        public async Task<ActionResult<QuestionModel>> GetQuestionById(Guid questionId)
        {
            QuestionModel question = await QuestionService.GetQuestionByIdAsync(questionId);
            return Ok(question);
        }

        [HttpPut, Route("VoteAQuestion/{questionId}")]
        public async Task<ActionResult> VoteAQuestion(Guid questionId)
        {
            await QuestionService.VoteAQuestionAsync(questionId);
            return Ok();
        }

        [HttpPut, Route("RemoveVoteForAQuestion/{questionId}")]
        public async Task<ActionResult> RemoveVoteForAQuestion(Guid questionId)
        {
            await QuestionService.RemoveVoteForAQuestionAsync(questionId);
            return Ok();
        }

        [HttpPut, Route("IncrementViews/{questionId}")]
        public async Task<ActionResult> IncrementViews(Guid questionId)
        {
            await QuestionService.IncrementViewsAsync(questionId);
            return Ok();
        }

        [HttpGet, Route("GetQuestionsAskedByUser/{userId}")]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestionsAskedByUser(Guid userId)
        {
            List<QuestionModel> questions = await QuestionService.GetQuestionsAskedByUserAsync(userId);
            return Ok(questions);
        }

        [HttpGet, Route("GetQuestionsAnsweredByUser/{userId}")]
        public async Task<ActionResult<List<QuestionModel>>> GetQuestionsAnsweredByUser(Guid userId)
        {
            List<QuestionModel> questions = await QuestionService.GetQuestionsAnsweredByUserAsync(userId);
            return Ok(questions);
        }

        [HttpGet("FilterQuestions/{categoryId}/{filterBy}/{timeSpan}/{signedUserId}")]
        public async Task<ActionResult<List<QuestionModel>>> FilterQuestions(Guid categoryId, string filterBy, string timeSpan, Guid signedUserId)
        {
            List<QuestionModel> questions = await QuestionService.FilterQuestionsAsync(categoryId, filterBy, timeSpan, signedUserId);
            return Ok(questions);
        }

        [HttpGet, Route("SearchQuestionsByKeyword/{categoryId}/{filterBy}/{timeSpan}/{signedUserId}/{keyword}")]
        public async Task<ActionResult<List<QuestionModel>>> SearchQuestionsByKeyword(Guid categoryId, string filterBy, string timeSpan, Guid signedUserId, string keyword)
        {
            List<QuestionModel> questions = await QuestionService.SearchQuestionsByKeywordAsync(categoryId, filterBy, timeSpan, signedUserId, keyword);
            return Ok(questions);
        }
    }
}