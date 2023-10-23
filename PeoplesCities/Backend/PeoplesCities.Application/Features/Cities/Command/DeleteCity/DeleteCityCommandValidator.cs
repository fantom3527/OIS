using FluentValidation;

namespace PeoplesCities.Application.Features.Cities.Command.DeleteCity
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator()
        {
            RuleFor(createCityCommand => createCityCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
