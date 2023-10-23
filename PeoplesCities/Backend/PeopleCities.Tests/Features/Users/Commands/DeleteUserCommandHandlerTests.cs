using PeopleCities.Tests.Common;
using PeopleCities.Tests.TestData;
using PeoplesCities.Application.Common.Exception;
using PeoplesCities.Application.Features.Users.Commands.DeleteUser;

namespace PeopleCities.Tests.Features.Users.Commands
{
    public class DeleteUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteUserCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteUserCommandHandler(dbContext);

            // Act
            await handler.Handle(new DeleteUserCommand
            {
                Id = UserTestData.UserIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(dbContext.Users.SingleOrDefault(user =>
                user.Id == UserTestData.UserIdForDelete));
        }

        [Fact]
        public async Task DeleteUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteUserCommandHandler(dbContext);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteUserCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
