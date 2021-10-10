using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.Replycomments
{
    public interface IReplyComment : IRepository<ReplyCommentObject> 
    {
        ReplyCommentObject Add(ReplyCommentObject order);

        void Update(ReplyCommentObject order);

        Task<ReplyCommentObject> GetAsync(int orderId);

        void Delete(string id);
    }
}
