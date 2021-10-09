using Domain.AggregatesModel.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class TodoEntityTypeConfiguration : IEntityTypeConfiguration<TodoObject>
    {
        public void Configure(EntityTypeBuilder<TodoObject> builder)
        {
            builder.ToTable("Todo");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Body)
                .HasMaxLength(1000)
                .HasColumnName("body");

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");

            builder.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .HasColumnName("createBy");

            builder.Property(e => e.Device)
                .HasMaxLength(255)
                .HasColumnName("device");

            builder.Property(e => e.Header)
                .HasMaxLength(255)
                .HasColumnName("header");

            builder.Property(e => e.IdTaskCard)
                .HasColumnName("idTaskCard")
                .IsRequired(true);

            builder.Property(e => e.IdUser)
                .HasColumnName("idUser")
                .IsRequired(true);

            builder.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            builder.Property(e => e.UpdateBy)
                .HasMaxLength(255)
                .HasColumnName("updateBy");

            builder.HasOne(d => d.IdTaskCardNavigation)
                .WithMany(p => p.Todos)
                .HasForeignKey(d => d.IdTaskCard)
                .HasConstraintName("FK_Todo_TaskCard");
        }
    }
}