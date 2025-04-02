using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasColumnName("name");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasColumnName("email"); ;

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(225)
                .HasColumnType("varchar(225)")
                .HasColumnName("password");

            builder.Property(u => u.Description)
                .HasMaxLength(225)
                .HasColumnType("varchar(225)")
                .HasColumnName("description");

            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(u => u.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");

        }
    }
}
