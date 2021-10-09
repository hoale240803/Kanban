using Domain.AggregatesModel.Attachments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class AttachmentEntityTypeConfiguration : IEntityTypeConfiguration<AttachmentObject>
    {
        public void Configure(EntityTypeBuilder<AttachmentObject> builder)
        {
            builder.ToTable("Attachment");

            builder.HasKey(o => o.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ExternalPath)
                .HasMaxLength(512)
                .HasColumnName("externalPath");

            builder.Property(e => e.FileId)
                .HasMaxLength(512)
                .HasColumnName("fileId");

            builder.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("fileName");

            builder.Property(e => e.IdComment).HasColumnName("idComment");

            builder.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

            builder.Property(e => e.InternalPath)
                .HasMaxLength(512)
                .HasColumnName("internalPath");
        }
    }
}