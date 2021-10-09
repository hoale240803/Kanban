using Domain.AggregatesModel.TaskCard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                .HasColumnType("date")
                .HasColumnName("duedate");

            builder.Property(e => e.EstimateTime).HasColumnName("estimateTime");

            builder.Property(e => e.IdCardList).HasColumnName("idCardList");

            builder.Property(e => e.IdUser).HasColumnName("idUser");

            builder.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");

            builder.Property(e => e.Priority)
                .HasMaxLength(255)
                .HasColumnName("priority");

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            builder.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            builder.Property(e => e.UpdateBy)
                .HasMaxLength(255)
                .HasColumnName("updateBy");

            //builder.HasOne(d => d.IdCardListNavigation)
            //    .WithMany(p => p.TaskCardObject)
            //    .HasForeignKey(d => d.IdCardList)
            //    .HasConstraintName("FK_TaskCard_CardList");
        }
    }
}