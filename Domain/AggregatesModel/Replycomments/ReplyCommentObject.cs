using Domain.AggregatesModel.Comments;
using Domain.SeedWork;

namespace Domain.AggregatesModel.Replycomments
{
    public class ReplyCommentObject : Entity, IAggregateRoot
    {
        public int? IdComment { get; set; }
        public string ContentBody { get; set; }
        public int? IdUser { get; set; }

        public virtual CommentObject IdCommentNavigation { get; set; }
    }
}