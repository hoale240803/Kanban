using Domain.AggregatesModel.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    public class CommmentEntityTypeConfiguration : IEntityTypeConfiguration<CommentObject>
    {
        public void Configure(EntityTypeBuilder<CommentObject> builder)
        {
            builder.ToTable("Comment");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Commentor)
                .HasMaxLength(255)
                .HasColumnName("commentor");

            builder.Property(e => e.ContentBody)
                .HasMaxLength(512)
                .HasColumnName("contentBody");

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");

            builder.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .HasColumnName("createBy");

            builder.Property(e => e.IdTaskCard)
            .HasColumnName("idTaskCard")
            .IsRequired(true);

            builder.Property(e => e.IdUser)
            .HasColumnName("idUser")
            .IsRequired(true);

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            builder.Property(e => e.UpdateBy)
                .HasMaxLength(255)
                .HasColumnName("updateBy");

            builder.HasOne(d => d.IdTaskCardNavigation)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdTaskCard)
                .HasConstraintName("FK_Comment_TaskCard");
        }
    }
}