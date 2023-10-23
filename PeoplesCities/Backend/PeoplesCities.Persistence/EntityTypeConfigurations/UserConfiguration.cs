using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PeoplesCities.Domain;

namespace PeoplesCities.Persistence.EntityTypeConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(city => city.Id);
            builder.HasIndex(city => city.Id).IsUnique();
            builder.Property(city => city.Id).HasColumnName("Id");
            builder.HasOne(u => u.City) // Определяем отношение один-ко-многим
                   .WithMany(c => c.Users) // Указываем свойство навигации в сущности "City"
                   .HasForeignKey(u => u.CityId); // Указываем внешний ключ в таблице "User"
            builder.Property(city => city.CityId).HasColumnName("City_Id");
            builder.Property(city => city.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(city => city.Email).HasColumnName("Email").HasMaxLength(80);
        }
    }
}
