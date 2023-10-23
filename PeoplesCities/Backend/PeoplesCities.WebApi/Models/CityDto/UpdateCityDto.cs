using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Features.Cities.Command.UpdateCity;

namespace PeoplesCities.WebApi.Models.CityDto
{
    public class UpdateCityDto : IMapWith<UpdateCityCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCityDto, UpdateCityCommand>()
                .ForPath(cityCommand => cityCommand.City.Id,
                    opt => opt.MapFrom(cityDto => cityDto.Id))
                .ForPath(cityCommand => cityCommand.City.Name,
                    opt => opt.MapFrom(cityDto => cityDto.Name))
                .ForPath(cityCommand => cityCommand.City.Description,
                    opt => opt.MapFrom(cityDto => cityDto.Description));
        }
    }
}
