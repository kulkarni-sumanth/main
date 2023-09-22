using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.Services
{
    public interface IUserService
    {
        public Task<UserModel> GetUserInfoAsync(Guid userId);
        public Task<List<UserModel>> SearchUsersByKeywordAsync(string keyword);

    }
}
