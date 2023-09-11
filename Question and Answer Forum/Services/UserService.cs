using Question_and_Answer_Forum.DB;

namespace Question_and_Answer_Forum.Services
{
    public class UserService : IUserService
    {
        public IDapperContext Context;
        public UserService(IDapperContext context)
        {
            this.Context = context;
        }
    }
}