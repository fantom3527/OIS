using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using PeoplesCities.Application.Features.Users.Commands.UpdateUser;

namespace PeoplesCities.WebApi.Models.UserDto
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForPath(userCommand => userCommand.User.Id,
                    opt => opt.MapFrom(userDto => userDto.Id))
                .ForPath(userCommand => userCommand.User.CityId,
                    opt => opt.MapFrom(userDto => userDto.CityId))
                .ForPath(userCommand => userCommand.User.Name,
                    opt => opt.MapFrom(userDto => userDto.Name))
                .ForPath(userCommand => userCommand.User.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }
    }
}
