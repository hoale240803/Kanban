using Domain.AggregatesModel.Replycomments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EntitiesConfig
{
    internal class ReplyCommentEntityTypeConfiguration : IEntityTypeConfiguration<ReplyCommentObject>
    {
        public void Configure(EntityTypeBuilder<ReplyCommentObject> builder)
        {
            throw new NotImplementedException();
        }
    }
}
