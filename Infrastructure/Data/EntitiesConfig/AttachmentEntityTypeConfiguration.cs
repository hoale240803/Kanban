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

            builder.Property(e => e._externalPath)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(512)
                .HasColumnName("externalPath");

            builder.Property(e => e._fileId)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(512)
                .HasColumnName("fileId")
                .IsRequired(true);

            builder.Property(e => e._fileName)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("fileName");

            builder.Property(e => e._category)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("category")
                .IsRequired(true);

            builder.Property(e => e._internalPath)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(512)
                .HasColumnName("internalPath");
        }
    }
}