using PeoplesCities.Persistence;

namespace PeopleCities.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly PeoplesCitiesDbContext dbContext;

        public TestCommandBase()
        {
            dbContext = PeoplesCitiesContextFactory.Create();
        }

        public void Dispose()
        {
            PeoplesCitiesContextFactory.Destroy(dbContext);
        }
    }
}
