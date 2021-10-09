using Domain.AggregatesModel.CardLists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class CardListEntityTypeConfiguration : IEntityTypeConfiguration<CardListObject>
    {
        public void Configure(EntityTypeBuilder<CardListObject> builder)
        {
            builder.ToTable("CardList");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("createAt");

            builder.Property(e => e.CreateBy)
                .HasMaxLength(255)
                .HasColumnName("createBy");

            builder.Property(e => e.Device)
                .HasMaxLength(255)
                .HasColumnName("device");

            builder.Property(e => e.IdRedemption).HasColumnName("idRedemption");

            builder.Property(e => e.IdUser).HasColumnName("idUser");

            builder.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");

            builder.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");

            builder.Property(e => e.UpdateBy)
                .HasMaxLength(255)
                .HasColumnName("updateBy");

            //builder.HasOne(d => d.IdRedemptionNavigation)
            //    .WithMany(p => p.CardLists)
            //    .HasForeignKey(d => d.IdRedemption)
            //    .HasConstraintName("FK_CardList_Redemption");

            //builder.HasOne(d => d.IdUserNavigation)
            //    .WithMany(p => p.CardLists)
            //    .HasForeignKey(d => d.IdUser)
            //    .HasConstraintName("FK_CardList_User");
        }
    }
}