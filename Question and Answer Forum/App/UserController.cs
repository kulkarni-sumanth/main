using Question_and_Answer_Forum.Services;
using Microsoft.AspNetCore.Mvc;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.App
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }
        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }

        [HttpGet, Route("GetUserInfo/{userId}")]
        public async Task<ActionResult<UserModel>> GetUserInfo(Guid userId)
        {
            UserModel user = await UserService.GetUserInfoAsync(userId);
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
