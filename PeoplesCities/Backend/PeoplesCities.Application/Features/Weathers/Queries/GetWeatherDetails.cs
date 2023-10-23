using MediatR;

namespace PeoplesCities.Application.Features.Weathers.Queries
{
    public class GetWeatherDetails : IRequest<WeatherDetailsVm>
    {
        public Guid CityId { get; set; }
    }
}
