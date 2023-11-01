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
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.Id).HasColumnName("Id");
            builder.HasOne(u => u.City) // Определяем отношение один-ко-многим
                   .WithMany(c => c.Users) // Указываем свойство навигации в сущности "City"
                   .HasForeignKey(u => u.CityId); // Указываем внешний ключ в таблице "User"
            builder.Property(user => user.CityId).HasColumnName("City_Id");
            builder.Property(user => user.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(user => user.Email).HasColumnName("Email").HasMaxLength(80);
            builder.Property(user => user.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
