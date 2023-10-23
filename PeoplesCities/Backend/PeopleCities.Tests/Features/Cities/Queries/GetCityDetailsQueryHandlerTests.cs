using AutoMapper;
using PeopleCities.Tests.Common;
using PeoplesCities.Application.Features.Cities.Queries;
using PeoplesCities.Application.Features.Cities.Queries.GetCityDetails;
using PeoplesCities.Persistence;
using Shouldly;

namespace PeopleCities.Tests.Features.Cities.Queries
{
    [Collection("QueryCollection")]
    public class GetCityDetailsQueryHandlerTests
    {
        private readonly PeoplesCitiesDbContext dbContext;
        private readonly IMapper Mapper;

        public GetCityDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            dbContext = fixture.dbContext;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCityDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCityDetailsQueryHandler(dbContext, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCityDetailsQuery
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CityDetailsVm>();
            result.Id.ShouldBeEquivalentTo(Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"));
            result.Name.ShouldBe("Name2");
            result.Description.ShouldBe("Description2");
        }
    }
}
