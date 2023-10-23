using Microsoft.EntityFrameworkCore;
using PeopleCities.Tests.TestData;
using PeoplesCities.Domain;
using PeoplesCities.Persistence;

namespace PeopleCities.Tests.Common
{
    public class PeoplesCitiesContextFactory
    {
        public static PeoplesCitiesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PeoplesCitiesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new PeoplesCitiesDbContext(options);

            context.Database.EnsureCreated();
            context.Cities.AddRange(CityTestData.Create());
            context.Users.AddRange(UserTestData.Create());
            context.SaveChanges();

            return context;
        }

        public static void Destroy(PeoplesCitiesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
