using MediatR;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Command.UpdateCity
{
    public class UpdateCityCommand : IRequest<Unit>
    {
        public City City { get; set; }
    }
}
