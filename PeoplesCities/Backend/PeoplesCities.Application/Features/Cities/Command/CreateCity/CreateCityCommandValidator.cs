using FluentValidation;

namespace PeoplesCities.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(createCityCommand => createCityCommand.City.Name).NotEmpty().MaximumLength(50);
            RuleFor(createCityCommand => createCityCommand.City.Description);
        }
    }
}
