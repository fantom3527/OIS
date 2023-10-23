using FluentValidation;

namespace PeoplesCities.Application.Features.Cities.Command.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(createCityCommand => createCityCommand.City.Id).NotEqual(Guid.Empty);
            RuleFor(createCityCommand => createCityCommand.City.Name).NotEmpty().MaximumLength(50);
            RuleFor(createCityCommand => createCityCommand.City.Description);
        }
    }
}
