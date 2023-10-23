using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Persistence;

namespace PeopleCities.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public PeoplesCitiesDbContext dbContext;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            dbContext = PeoplesCitiesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IPeoplesCitiesDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            PeoplesCitiesContextFactory.Destroy(dbContext);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
