using Microsoft.EntityFrameworkCore;
using PeopleCities.Tests.Common;
using PeopleCities.Tests.TestData;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Features.Users.Commands.UpdateUser;
using PeoplesCities.Domain;

namespace PeopleCities.Tests.Features.Users.Commands
{
    public class UpdateUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateUserCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateUserCommandHandler(dbContext);
            var cityId = Guid.NewGuid();
            var updatedName = "new name";
            var updatedEmail = "new email";

            // Act
            await handler.Handle(new UpdateUserCommand
            {
                User = new User
                {
                    Id = UserTestData.UserIdForUpdate,
                    CityId = cityId,
                    Name = updatedName,
                    Email = updatedEmail
                }
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await dbContext.Users.SingleOrDefaultAsync(user =>
                user.Id == UserTestData.UserIdForUpdate &&
                user.CityId == cityId &&
                user.Name == updatedName &&
                user.Email == updatedEmail));
        }

        [Fact]
        public async Task UpdateUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateUserCommandHandler(dbContext);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateUserCommand
                    {
                        User = new User
                        {
                            Id = Guid.NewGuid()
                        }
                    },
                    CancellationToken.None));
        }
    }
}
