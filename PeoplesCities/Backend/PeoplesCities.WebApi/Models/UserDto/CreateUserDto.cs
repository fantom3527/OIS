using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Features.Cities.Command.CreateCity;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;

namespace PeoplesCities.WebApi.Models.UserDto
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForPath(userCommand => userCommand.User.CityId,
                    opt => opt.MapFrom(userDto => userDto.CityId))
                .ForPath(userCommand => userCommand.User.Name,
                    opt => opt.MapFrom(userDto => userDto.Name))
                .ForPath(userCommand => userCommand.User.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }
    }
}
