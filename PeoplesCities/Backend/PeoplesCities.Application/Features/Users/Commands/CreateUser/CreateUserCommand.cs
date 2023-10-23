using MediatR;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public User User { get; set; }
    }
}
