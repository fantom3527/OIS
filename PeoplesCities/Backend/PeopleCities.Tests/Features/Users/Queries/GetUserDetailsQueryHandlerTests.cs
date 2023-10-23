using AutoMapper;
using PeopleCities.Tests.Common;
using PeoplesCities.Application.Features.Users.Queries.GetUserDetails;
using PeoplesCities.Persistence;
using Shouldly;

namespace PeopleCities.Tests.Features.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetUserDetailsQueryHandlerTests
    {
        private readonly PeoplesCitiesDbContext dbContext;
        private readonly IMapper Mapper;

        public GetUserDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            dbContext = fixture.dbContext;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUserDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetUserDetailsQueryHandler(dbContext, Mapper);

            // Act
            var result = await handler.Handle(
                new GetUserDetailsQuery
                {
                    //TODO: Желательно изменить конкретный Guid в во запросах на guid из класса UserTestData - возможно, чтобы выбирался рандомный.
                    //TODO: Также сделать и для других полей классов User и City.
                    Id = Guid.Parse("A34565BB-5AC2-4AFA-8A28-2616F675B825")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<UserDetailsVm>();
            result.Id.ShouldBeEquivalentTo(Guid.Parse("A34565BB-5AC2-4AFA-8A28-2616F675B825"));
            result.CityId.ShouldBeEquivalentTo(Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"));
            result.Name.ShouldBe("Name1");
            result.Email.ShouldBe("Email1");
        }
    }
}
