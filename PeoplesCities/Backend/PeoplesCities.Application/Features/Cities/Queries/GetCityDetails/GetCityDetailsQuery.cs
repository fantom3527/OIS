using MediatR;

namespace PeoplesCities.Application.Features.Cities.Queries.GetCityDetails
{
    public class GetCityDetailsQuery : IRequest<CityDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
