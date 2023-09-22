using Question_and_Answer_Forum.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Models;
using Question_and_Answer_Forum.Services;

namespace Question_and_Answer_Forum.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public IQuestionService QuestionService { get; set; }
        public QuestionController(IQuestionService questionService)
        {
            this.QuestionService = questionService;
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

        [HttpPost, Route("VoteAQuestion/{questionId}")]
        public async Task<ActionResult> VoteAQuestion(Guid questionId)
        {
            await QuestionService.VoteAQuestionAsync(questionId);
            return Ok();
        }

        [HttpPost, Route("RemoveVoteForAQuestion/{questionId}")]
        public async Task<ActionResult> RemoveVoteForAQuestion(Guid questionId)
        {
            await QuestionService.RemoveVoteForAQuestionAsync(questionId);
            return Ok();
        }

        [HttpPost, Route("IncrementViews/{questionId}")]
        public async Task<ActionResult> IncrementViews(Guid questionId)
        {
            await QuestionService.IncrementViewsAsync(questionId);
            return Ok();
        }

        [HttpGet("FilterQuestions/{show}/{sortBy}/{categoryId?}")]
        public async Task<ActionResult<List<QuestionModel>>> FilterQuestions(string categoryId, string show, string sortBy)
        {
            List<QuestionModel> questions = await QuestionService.FilterQuestionsAsync(categoryId, show, sortBy);
            return Ok(questions);
        }

        [HttpGet, Route("SearchQuestionsByKeyword/{keyword}")]
        public async Task<ActionResult<List<QuestionModel>>> SearchQuestionsByKeyword(string categoryId, string show, string sortBy, string keyword)
        {
            List<QuestionModel> questions = await QuestionService.SearchQuestionsByKeywordAsync(categoryId, show, sortBy, keyword);
            return Ok(questions);
        }
    }
}