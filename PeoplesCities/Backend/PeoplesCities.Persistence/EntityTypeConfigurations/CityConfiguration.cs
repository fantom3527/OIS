using PeoplesCities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PeoplesCities.Persistence.EntityTypeConfigurations
{
    class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(city => city.Id);
            builder.Property(city => city.Id).HasColumnName("Id"); 
            builder.Property(city => city.Name).HasColumnName("Name").HasMaxLength(50).IsRequired(); 
            builder.Property(city => city.Description).HasColumnName("Description").HasMaxLength(250);
            builder.Property(city => city.Ts).HasColumnName("TS").HasDefaultValueSql("now()");
        }
    }
}
