using CorporateQnA.DB;

namespace CorporateQnA.Services
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