using Domain.AggregatesModel.CardLists;
using Domain.AggregatesModel.TaskCard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class TaskCardEntityTypeConfiguration : IEntityTypeConfiguration<TaskCardObject>
    {
        public void Configure(EntityTypeBuilder<TaskCardObject> builder)
        {
            builder.ToTable("TaskCard");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e._actualTime).HasColumnName("actualTime");

            builder.Property(e => e._createAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");

            builder.Property(e => e._createBy)
                .HasMaxLength(255)
                .HasColumnName("createBy");

            builder.Property(e => e._device)
                .HasMaxLength(255)
                .HasColumnName("device");

            builder.Property(e => e._duedate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnType("date")
                .HasColumnName("duedate");

            builder.Property(e => e._estimateTime).HasColumnName("estimateTime");

            builder.Property(e => e._idCardList).HasColumnName("idCardList");

            builder.Property(e => e._idUser).HasColumnName("idUser");

            builder.Property(e => e._location)
                .HasMaxLength(255)
                .HasColumnName("location");

            builder.Property(e => e._priority)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("priority");

            builder.Property(e => e._status)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(50)
                .HasColumnName("status")
                .HasDefaultValue("normal");

            builder.Property(e => e._title)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("title")
                .IsRequired(true);

            builder.Property(e => e._updateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt")
                .IsRequired(true);

            builder.Property(e => e._updateBy)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("updateBy")
                .IsRequired(true);

            builder.Property(e => e._taskCardOrder)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnType("real")
                .HasColumnName("updateBy")
                .IsRequired(true);


            var attachmentNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.Attachments));
            attachmentNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var commentNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.Comments));
            commentNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var todoNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.Todos));
            todoNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}