using Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserObject>
    {
        public void Configure(EntityTypeBuilder<UserObject> builder)
        {
            //builder.Entity<UserObject>(entity =>
            //{
            //});
            builder.ToTable("User");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.AccessFailedCount).HasColumnName("accessFailedCount");

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");

            builder.Property(e => e.EmailConfirmed).HasColumnName("emailConfirmed");

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(512)
                .HasColumnName("hashedPassword");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phoneNumber");

            builder.Property(e => e.TwoFactorEnabled).HasColumnName("twoFactorEnabled");

            builder.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("userName");
        }
    }
}