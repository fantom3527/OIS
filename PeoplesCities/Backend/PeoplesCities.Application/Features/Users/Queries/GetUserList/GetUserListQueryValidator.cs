using FluentValidation;

namespace PeoplesCities.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
    {
        public GetUserListQueryValidator()
        {
            RuleFor(x => x.CityId).NotEqual(Guid.Empty);
        }
    }
}
