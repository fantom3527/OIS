using PeoplesCities.Domain;

namespace PeopleCities.Tests.TestData
{
    internal class CityTestData
    {
        public static Guid CityIdForDelete = Guid.NewGuid();
        public static Guid CityIdForUpdate = Guid.NewGuid();

        public static List<City> Create()
        {
            var cities = new List<City>() {
                new City
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Name = "Name1",
                    Description = "Description1",
                    Ts = DateTime.Today
                },
                new City
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Name = "Name2",
                    Description = "Description2",
                    Ts = DateTime.Today
                },
                new City
                {
                    Id = CityIdForDelete,
                    Name = "Name3",
                    Description = "Description3",
                    Ts = DateTime.Today
                },
                new City
                {
                    Id = CityIdForUpdate,
                    Name = "Name4",
                    Description = "Description4",
                    Ts = DateTime.Today
                }
            };

            return cities;
        }
    }
}
