using Domain.AggregatesModel.Replycomments;
using Domain.AggregatesModel.TaskCard;
using Domain.AggregatesModel.Users;
using Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Domain.AggregatesModel.Comments
{
    public class CommentObject : Entity, IAggregateRoot
    {
        public CommentObject()
        {
            ReplyComments = new HashSet<ReplyCommentObject>();
        }

        public int? IdTaskCard { get; set; }
        public string Commentor { get; set; }
        public string ContentBody { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string IdUser { get; set; }

        public virtual TaskCardObject IdTaskCardNavigation { get; set; }
        public virtual UserObject IdUserCardNavigation { get; set; }
        public virtual ICollection<ReplyCommentObject> ReplyComments { get; set; }
    }
}