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

            builder.Property(e => e.ActualTime).HasColumnName("actualTime");

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");

            builder.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .HasColumnName("createBy");

            builder.Property(e => e.Device)
                .HasMaxLength(255)
                .HasColumnName("device");

            builder.Property(e => e.Duedate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnType("date")
                .HasColumnName("duedate");

            builder.Property(e => e.EstimateTime).HasColumnName("estimateTime");

            builder.Property(e => e.IdCardList).HasColumnName("idCardList");

            builder.Property(e => e.IdUser).HasColumnName("idUser");

            builder.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");

            builder.Property(e => e.Priority)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("priority");

            builder.Property(e => e.Status)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(50)
                .HasColumnName("status")
                .HasDefaultValue("normal");

            builder.Property(e => e.Title)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("title")
                .IsRequired(true);

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt")
                .IsRequired(true);

            builder.Property(e => e.UpdateBy)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasMaxLength(255)
                .HasColumnName("updateBy")
                .IsRequired(true);

            //builder.HasOne(d => d.IdCardListNavigation)
            //    .WithMany(p => p.TaskCardObject)
            //    .HasForeignKey(d => d.IdCardList)
            //    .HasConstraintName("FK_TaskCard_CardList");
            var taggedUserNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.TagUsers));
            taggedUserNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var attachmentNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.Attachments));
            attachmentNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var commentNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.Comments));
            commentNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var todoNavigation = builder.Metadata.FindNavigation(nameof(TaskCardObject.Todos));
            todoNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<CardListObject>()
            .WithMany()
            .HasForeignKey("IdCardList")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}