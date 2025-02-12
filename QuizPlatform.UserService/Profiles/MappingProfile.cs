using AutoMapper;
using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User,Db.Models.User>().ReverseMap();
    }
}