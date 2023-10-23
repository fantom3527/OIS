using MediatR;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommand : IRequest<Guid>
    {
        public City City { get; set; }
    }
}
