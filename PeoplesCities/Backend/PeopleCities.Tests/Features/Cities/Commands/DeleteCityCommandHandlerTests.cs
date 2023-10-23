using PeopleCities.Tests.Common;
using PeopleCities.Tests.TestData;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Features.Cities.Command.DeleteCity;

namespace PeopleCities.Tests.Features.Cities.Commands
{
    public class DeleteCityCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCityCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCityCommandHandler(dbContext);

            // Act
            await handler.Handle(new DeleteCityCommand
            {
                Id = CityTestData.CityIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(dbContext.Cities.SingleOrDefault(city =>
                city.Id == CityTestData.CityIdForDelete));
        }

        [Fact]
        public async Task DeleteCityCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCityCommandHandler(dbContext);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteCityCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
