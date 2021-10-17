//using Infrastructure.Idempotency;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.EntitiesConfig
//{
//    internal class ClientRequestEntityTypeConfiguration
//        : IEntityTypeConfiguration<ClientRequest>
//    {
//        public void Configure(EntityTypeBuilder<ClientRequest> requestConfiguration)
//        {
//            requestConfiguration.ToTable("Requests");
//            requestConfiguration.HasKey(cr => cr.Id);
//            requestConfiguration.Property(cr => cr.Name).IsRequired();
//            requestConfiguration.Property(cr => cr.Time).IsRequired();
//        }
//    }
//}