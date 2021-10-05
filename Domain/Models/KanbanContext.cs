using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Models
{
    public partial class KanbanContext : DbContext
    {
        public KanbanContext()
        {
        }

        public KanbanContext(DbContextOptions<KanbanContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<CardList> CardLists { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gift> Gifts { get; set; }
        public virtual DbSet<Redemption> Redemptions { get; set; }
        public virtual DbSet<RemptionGift> RemptionGifts { get; set; }
        public virtual DbSet<ReplyComment> ReplyComments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagUser> TagUsers { get; set; }
        public virtual DbSet<TaskCard> TaskCards { get; set; }
        public virtual DbSet<TaskCardHistory> TaskCardHistories { get; set; }
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=Kanban;User Id=sa;Password=1234;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.Property(e => e.RoleId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExternalPath)
                    .HasMaxLength(512)
                    .HasColumnName("externalPath");

                entity.Property(e => e.FileId)
                    .HasMaxLength(512)
                    .HasColumnName("fileId");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .HasColumnName("fileName");

                entity.Property(e => e.IdComment).HasColumnName("idComment");

                entity.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

                entity.Property(e => e.InternalPath)
                    .HasMaxLength(512)
                    .HasColumnName("internalPath");

                entity.HasOne(d => d.IdTaskCardNavigation)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.IdTaskCard)
                    .HasConstraintName("FK_Attachment_TaskCard");
            });

            modelBuilder.Entity<CardList>(entity =>
            {
                entity.ToTable("CardList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .HasColumnName("createBy");

                entity.Property(e => e.Device)
                    .HasMaxLength(255)
                    .HasColumnName("device");

                entity.Property(e => e.IdRedemption).HasColumnName("idRedemption");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .HasColumnName("updateBy");

                entity.HasOne(d => d.IdRedemptionNavigation)
                    .WithMany(p => p.CardLists)
                    .HasForeignKey(d => d.IdRedemption)
                    .HasConstraintName("FK_CardList_Redemption");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.CardLists)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_CardList_User");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Commentor)
                    .HasMaxLength(255)
                    .HasColumnName("commentor");

                entity.Property(e => e.ContentBody)
                    .HasMaxLength(512)
                    .HasColumnName("contentBody");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .HasColumnName("createBy");

                entity.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .HasColumnName("updateBy");

                entity.HasOne(d => d.IdTaskCardNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdTaskCard)
                    .HasConstraintName("FK_Comment_TaskCard");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.IdRedemption).HasColumnName("idRedemption");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.ToTable("Gift");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Point).HasColumnName("point");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Redemption>(entity =>
            {
                entity.ToTable("Redemption");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .HasColumnName("createBy");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdGift).HasColumnName("idGift");

                entity.Property(e => e.TypeOfRedemption)
                    .HasMaxLength(50)
                    .HasColumnName("typeOfRedemption");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Redemptions)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Redemption_Employee");
            });

            modelBuilder.Entity<RemptionGift>(entity =>
            {
                entity.HasKey(e => new { e.IdRedemption, e.IdGift });

                entity.ToTable("RemptionGift");

                entity.Property(e => e.IdRedemption).HasColumnName("idRedemption");

                entity.Property(e => e.IdGift).HasColumnName("idGift");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdGiftNavigation)
                    .WithMany(p => p.RemptionGifts)
                    .HasForeignKey(d => d.IdGift)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RemptionGift_Gift");

                entity.HasOne(d => d.IdRedemptionNavigation)
                    .WithMany(p => p.RemptionGifts)
                    .HasForeignKey(d => d.IdRedemption)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RemptionGift_Redemption");
            });

            modelBuilder.Entity<ReplyComment>(entity =>
            {
                entity.ToTable("ReplyComment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentBody)
                    .HasMaxLength(512)
                    .HasColumnName("contentBody");

                entity.Property(e => e.IdComment).HasColumnName("idComment");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithMany(p => p.ReplyComments)
                    .HasForeignKey(d => d.IdComment)
                    .HasConstraintName("FK_ReplyComment_Comment");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TagUser>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdUser })
                    .HasName("PK_TaggedPerson");

                entity.ToTable("TagUser");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .HasColumnName("createBy");

                entity.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.TypeOfTag)
                    .HasMaxLength(255)
                    .HasColumnName("typeOfTag");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .HasColumnName("updateBy");

                entity.HasOne(d => d.IdTaskCardNavigation)
                    .WithMany(p => p.TagUsers)
                    .HasForeignKey(d => d.IdTaskCard)
                    .HasConstraintName("FK_TaggedPerson_TaskCard");
            });

            modelBuilder.Entity<TaskCard>(entity =>
            {
                entity.ToTable("TaskCard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActualTime).HasColumnName("actualTime");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .HasColumnName("createBy");

                entity.Property(e => e.Device)
                    .HasMaxLength(255)
                    .HasColumnName("device");

                entity.Property(e => e.Duedate)
                    .HasColumnType("date")
                    .HasColumnName("duedate");

                entity.Property(e => e.EstimateTime).HasColumnName("estimateTime");

                entity.Property(e => e.IdCardList).HasColumnName("idCardList");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("priority");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .HasColumnName("updateBy");

                entity.HasOne(d => d.IdCardListNavigation)
                    .WithMany(p => p.TaskCards)
                    .HasForeignKey(d => d.IdCardList)
                    .HasConstraintName("FK_TaskCard_CardList");
            });

            modelBuilder.Entity<TaskCardHistory>(entity =>
            {
                entity.ToTable("TaskCardHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAttachment).HasColumnName("idAttachment");

                entity.Property(e => e.IdComment).HasColumnName("idComment");

                entity.Property(e => e.IdTaggedPerson).HasColumnName("idTaggedPerson");

                entity.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

                entity.Property(e => e.IdTodo).HasColumnName("idTodo");

                entity.Property(e => e.IdUser).HasColumnName("idUser");
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("Todo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasMaxLength(1000)
                    .HasColumnName("body");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(255)
                    .HasColumnName("createBy");

                entity.Property(e => e.Device)
                    .HasMaxLength(255)
                    .HasColumnName("device");

                entity.Property(e => e.Header)
                    .HasMaxLength(255)
                    .HasColumnName("header");

                entity.Property(e => e.IdTaskCard).HasColumnName("idTaskCard");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(255)
                    .HasColumnName("updateBy");

                entity.HasOne(d => d.IdTaskCardNavigation)
                    .WithMany(p => p.Todos)
                    .HasForeignKey(d => d.IdTaskCard)
                    .HasConstraintName("FK_Todo_TaskCard");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessFailedCount).HasColumnName("accessFailedCount");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasColumnName("emailConfirmed");

                entity.Property(e => e.HashedPassword)
                    .HasMaxLength(512)
                    .HasColumnName("hashedPassword");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("twoFactorEnabled");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdRole });

                entity.ToTable("UserRole");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.ToTable("UserToken");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.Expire)
                    .HasColumnType("datetime")
                    .HasColumnName("expire");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsExpired).HasColumnName("isExpired");

                entity.Property(e => e.RevokeAt)
                    .HasColumnType("datetime")
                    .HasColumnName("revokeAt");

                entity.Property(e => e.Token)
                    .HasMaxLength(512)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserToken_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
