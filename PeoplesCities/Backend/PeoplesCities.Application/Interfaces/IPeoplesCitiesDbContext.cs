using Microsoft.EntityFrameworkCore;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Interfaces
{
    public interface IPeoplesCitiesDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<City> Cities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
