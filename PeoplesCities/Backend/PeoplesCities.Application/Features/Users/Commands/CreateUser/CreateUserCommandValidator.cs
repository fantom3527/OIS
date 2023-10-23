using FluentValidation;

namespace PeoplesCities.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.User.CityId).NotEqual(Guid.Empty);
            RuleFor(createUserCommand => createUserCommand.User.Name).NotEmpty().MaximumLength(50);
            RuleFor(createUserCommand => createUserCommand.User.Email).MaximumLength(80);
        }
    }
}
