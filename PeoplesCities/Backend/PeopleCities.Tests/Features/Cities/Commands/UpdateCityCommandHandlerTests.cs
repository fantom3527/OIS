using Microsoft.EntityFrameworkCore;
using PeopleCities.Tests.Common;
using PeopleCities.Tests.TestData;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Features.Cities.Command.UpdateCity;
using PeoplesCities.Domain;

namespace PeopleCities.Tests.Features.Cities.Commands
{
    public class UpdateCityCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateCityCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCityCommandHandler(dbContext);
            var updatedName = "new name";
            var updatedDescription = "new Description";

            // Act
            await handler.Handle(new UpdateCityCommand
            {
                City = new City
                {
                    Id = CityTestData.CityIdForUpdate,
                    Name = updatedName,
                    Description = updatedDescription
                }
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await dbContext.Cities.SingleOrDefaultAsync(user =>
                user.Id == CityTestData.CityIdForUpdate &&
                user.Name == updatedName &&
                user.Description == updatedDescription));
        }

        [Fact]
        public async Task UpdateCityCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCityCommandHandler(dbContext);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateCityCommand
                    {
                        City = new City
                        {
                            Id = Guid.NewGuid()
                        }                        
                    },
                    CancellationToken.None));
        }
    }
}
