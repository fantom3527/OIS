using Microsoft.EntityFrameworkCore;
using PeopleCities.Tests.Common;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using PeoplesCities.Domain;

namespace PeopleCities.Tests.Features.Users.Commands
{
    public class CreateUserCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateUserCommandHandler_Success()
        {
            // Arrange - Подготовка данных.
            var handler = new CreateUserCommandHandler(dbContext);
            var cityId = Guid.NewGuid();
            var userName = "user name";
            var userEmail = "user Email";

            // Act - Выполнение логиик.
            var userId = await handler.Handle(
            new CreateUserCommand
            {
                User = new User
                {
                    CityId = cityId,
                    Name = userName,
                    Email = userEmail,
                }
            },
            CancellationToken.None);

            // Assert - Проверка результата.
            Assert.NotNull(await dbContext.Users.SingleOrDefaultAsync(user =>
                                      user.Id == userId && 
                                      user.CityId == cityId &&
                                      user.Name == userName &&
                                      user.Email == userEmail));
        }
    }
}
