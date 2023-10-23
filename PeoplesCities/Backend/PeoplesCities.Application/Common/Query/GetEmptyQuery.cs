using MediatR;
using PeoplesCities.Application.Features.Cities.Queries.GetCityList;

namespace PeoplesCities.Application.Common.Query
{
    public class GetEmptyQuery : IRequest<CityListVm> { }
}
