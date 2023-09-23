using Question_and_Answer_Forum.Services;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet, Route("GetUserById/{userId}")]
        public async Task<ActionResult<UserModel>> GetUserById(Guid userId)
        {
            UserModel user = await UserService.GetUserByIdAsync(userId);
            return Ok(user);
        }

        [HttpGet, Route("SearchUsersByKeyword/{keyword}")]
        public async Task<ActionResult<List<UserModel>>> SearchUsersByKeyword(string keyword)
        {
            List<UserModel> users = await UserService.SearchUsersByKeywordAsync(keyword);
            return Ok(users);
        }
    }
}
