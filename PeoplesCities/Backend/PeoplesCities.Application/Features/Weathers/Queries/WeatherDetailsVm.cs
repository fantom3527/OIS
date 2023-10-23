using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Weathers.Queries
{
    public class WeatherDetailsVm : IMapWith<Weather>
    {
        public Guid CityId { get; set; }
        public float Temperature { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Weather, WeatherDetailsVm>()
                .ForMember(weatherVm => weatherVm.CityId,
                    opt => opt.MapFrom(weather => weather.CityId))
                .ForMember(weatherVm => weatherVm.Temperature,
                    opt => opt.MapFrom(weather => weather.Temperature))
                .ForMember(weatherVm => weatherVm.Description,
                    opt => opt.MapFrom(weather => weather.Description));
        }
    }
}
