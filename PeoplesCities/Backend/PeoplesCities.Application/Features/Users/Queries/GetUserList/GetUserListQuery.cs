using MediatR;

namespace PeoplesCities.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public Guid CityId { get; set; }
    }
}
