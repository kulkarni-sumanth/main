using AutoMapper;
using Question_and_Answer_Forum.Data;
using Question_and_Answer_Forum.Models;

namespace Question_and_Answer_Forum.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserStats, UserModel>();
        }
    }
}