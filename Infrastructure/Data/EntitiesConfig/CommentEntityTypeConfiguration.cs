using Domain.AggregatesModel.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntitiesConfig
{
    class CommmentEntityTypeConfiguration : IEntityTypeConfiguration<CommentObject>
    {
        public void Configure(EntityTypeBuilder<CommentObject> builder)
        {
            throw new NotImplementedException();
        }
    }
}
