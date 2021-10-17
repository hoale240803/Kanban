//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Domain.DataModels
//{
//    internal class ClientRequestEntityTypeConfiguration : IEntityTypeConfiguration<ClientRequest>
//    {
//        public void Configure(EntityTypeBuilder<ClientRequest> builder)
//        {
//            builder.ToTable("requests");
//            builder.HasKey(cr => cr.Id);
//            builder.Property(cr => cr.Name).IsRequired();
//            builder.Property(cr => cr.Time).IsRequired();
//        }
//    }
//}