using FluentValidation;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.User.Id).NotEqual(Guid.Empty);
            RuleFor(createUserCommand => createUserCommand.User.CityId).NotEqual(Guid.Empty);
            RuleFor(createUserCommand => createUserCommand.User.Name).NotEmpty().MaximumLength(80);
            RuleFor(createUserCommand => createUserCommand.User.Email).MaximumLength(80);
        }
    }
}
