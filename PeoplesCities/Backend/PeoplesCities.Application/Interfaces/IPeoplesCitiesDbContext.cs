using Microsoft.EntityFrameworkCore;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Interfaces
{
    public interface IPeoplesCitiesDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<City> City { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
