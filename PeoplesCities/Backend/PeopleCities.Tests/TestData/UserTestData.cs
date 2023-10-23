using PeoplesCities.Domain;

namespace PeopleCities.Tests.TestData
{
    internal class UserTestData
    {
        public static Guid UserIdForDelete = Guid.NewGuid();
        public static Guid UserIdForUpdate = Guid.NewGuid();

        public static List<User> Create()
        {
            var users = new List<User>() {
                new User
                {
                    Id = Guid.Parse("A34565BB-5AC2-4AFA-8A28-2616F675B825"),
                    Name = "Name1",
                    CityId = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Email = "Email1",
                },
                new User
                {
                    Id = Guid.Parse("A34F7C29-891B-4BE1-8504-21F84F262084"),
                    Name = "Name2",
                    CityId = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Email = "Email2",
                },
                new User
                {
                    Id = UserIdForDelete,
                    Name = "Name3",
                    CityId = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Email = "Email3",
                },
                new User
                {
                    Id = UserIdForUpdate,
                    Name = "Name4",
                    CityId = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Email = "Email4",
                }
            };

            return users;
        }
    }
}
