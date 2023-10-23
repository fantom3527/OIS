using MediatR;

namespace PeoplesCities.Application.Features.Cities.Command.DeleteCity
{
    public class DeleteCityCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
