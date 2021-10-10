using Domain.AggregatesModel.Comments;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CommentObject Add(CommentObject order)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentObject> GetAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentObject order)
        {
            throw new NotImplementedException();
        }
    }
}
