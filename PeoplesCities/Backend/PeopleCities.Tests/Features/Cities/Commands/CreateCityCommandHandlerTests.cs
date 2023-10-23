using Microsoft.EntityFrameworkCore;
using PeopleCities.Tests.Common;
using PeoplesCities.Application.Features.Cities.Command.CreateCity;
using PeoplesCities.Domain;

namespace PeopleCities.Tests.Features.Cities.Commands
{
    public class CreateCityCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCityCommandHandler_Success()
        {
            // Arrange - Подготовка данных.
            var handler = new CreateCityCommandHandler(dbContext);
            var cityName = "city name";
            var cityDescription = "city details";

            // Act - Выполнение логиик.
            var cityId = await handler.Handle(
            new CreateCityCommand
            {
                City = new City
                {
                    Name = cityName,
                    Description = cityDescription,
                }
            },
            CancellationToken.None);

            // Assert - Проверка результата.
            Assert.NotNull(await dbContext.Cities.SingleOrDefaultAsync(city =>
                                      city.Id == cityId && city.Name == cityName &&
                                      city.Description == cityDescription));
        }
    }
}
