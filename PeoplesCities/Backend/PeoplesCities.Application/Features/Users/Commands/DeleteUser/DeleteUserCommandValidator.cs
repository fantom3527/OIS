using FluentValidation;

namespace PeoplesCities.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
