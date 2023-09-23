using AutoMapper;
using Question_and_Answer_Forum.Data;
using Dapper;
using Question_and_Answer_Forum.Models;
using System.Data;
using Question_and_Answer_Forum.Services.DbServices;

namespace Question_and_Answer_Forum.Services
{
    public class UserService : IUserService
    {
        public IDapperContext Context;
        public IMapper Mapper;
        public UserService(IDapperContext context,IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<UserModel> GetUserByIdAsync(Guid userId)
        {
            string queryToRetrieveUser = "SELECT UserId AS Id, Name, JobTitle, Department, Location, ProfilePicture FROM Users WHERE UserId = @UserId";

            using (var connection = Context.CreateConnection())
            {
                User user = await connection.QuerySingleAsync<User>(queryToRetrieveUser, new { userId });
                var userStats = connection.QuerySingleOrDefault("GetStatsOfUser", new { userId }, commandType: CommandType.StoredProcedure);

                UserModel userModel = Mapper.Map<UserModel>(user);
                Mapper.Map(userStats, userModel);

                return userModel;
            }
        }

        public async Task<List<UserModel>> SearchUsersByKeywordAsync(string keyword)
        {
            keyword = '%' + keyword + '%';
            string query = "SELECT UserId FROM Users WHERE Name LIKE @keyword OR JobTitle LIKE @keyword OR Department LIKE @keyword OR Location LIKE @keyword";
            using (var connection = Context.CreateConnection())
            {
                IEnumerable<Guid> UserIds = await connection.QueryAsync<Guid>(query, new { keyword });
                List<UserModel> users = new List<UserModel>();
                foreach (Guid userId in UserIds)
                {
                    users.Add(await GetUserByIdAsync(userId));
                }
                return users;
            }
        }
    }
}