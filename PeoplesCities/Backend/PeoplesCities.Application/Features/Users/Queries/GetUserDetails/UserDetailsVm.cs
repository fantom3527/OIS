using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.CityId,
                    opt => opt.MapFrom(user => user.CityId))
                .ForMember(userVm => userVm.Name,
                    opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email));
        }
    }
}
