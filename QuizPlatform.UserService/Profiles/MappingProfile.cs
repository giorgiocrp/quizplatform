using AutoMapper;
using QuizPlatform.UserService.Features.Roles.DTOs;
using QuizPlatform.UserService.Features.Users.DTOs;
using QuizPlatform.UserService.Model.Entities;

namespace QuizPlatform.UserService.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User,Db.Models.User>().ReverseMap();
        CreateMap<Role,Db.Models.Role>().ReverseMap();
        
        //DTO
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<UpdateUserDto, User>().ReverseMap();
        CreateMap<CreateRoleDto, Role>().ReverseMap();
        CreateMap<UpdateRoleDto, Role>().ReverseMap();
    }
}