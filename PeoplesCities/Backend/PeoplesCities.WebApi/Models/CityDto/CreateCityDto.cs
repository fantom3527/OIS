using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Features.Cities.Command.CreateCity;

namespace PeoplesCities.WebApi.Models.CityDto
{
    public class CreateCityDto : IMapWith<CreateCityCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCityDto, CreateCityCommand>()
                .ForPath(cityCommand => cityCommand.City.Name,
                    opt => opt.MapFrom(cityDto => cityDto.Name))
                .ForPath(cityCommand => cityCommand.City.Description,
                    opt => opt.MapFrom(cityDto => cityDto.Description));
        }
    }
}
