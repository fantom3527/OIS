using Microsoft.EntityFrameworkCore;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;
using PeoplesCities.Persistence.EntityTypeConfigurations;

namespace PeoplesCities.Persistence
{
    //TODO: Изменить название PeoplesCitiesDbContext на AppDbContext
    public class PeoplesCitiesDbContext : DbContext, IPeoplesCitiesDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

        public PeoplesCitiesDbContext(DbContextOptions<PeoplesCitiesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
