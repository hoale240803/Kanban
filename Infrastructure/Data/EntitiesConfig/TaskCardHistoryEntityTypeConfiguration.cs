using Domain.AggregatesModel.TaskCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class TaskCardHistoryEntityTypeConfiguration : IEntityTypeConfiguration<TaskCardHistoryObject>
    {
        public void Configure(EntityTypeBuilder<TaskCardHistoryObject> builder)
        {
            builder.ToTable("TaskCardHistory");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.IdAttachment).HasColumnName("idAttachment");

            builder.Property(e => e.IdComment).HasColumnName("idComment");

            builder.Property(e => e.IdTaggedPerson).HasColumnName("idTaggedPerson");

            builder.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

            builder.Property(e => e.IdTodo).HasColumnName("idTodo");

            builder.Property(e => e.IdUser).HasColumnName("idUser");
        }
    }
}