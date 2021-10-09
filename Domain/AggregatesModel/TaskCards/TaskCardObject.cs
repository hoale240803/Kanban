using Domain.AggregatesModel.Attachments;
using Domain.AggregatesModel.CardLists;
using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.Todos;
using Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Domain.AggregatesModel.TaskCard
{
    public class TaskCardObject : Entity, IAggregateRoot
    {
        public TaskCardObject()
        {
            //Attachments = new HashSet<AttachmentObject>();
            Comments = new HashSet<CommentObject>();
            TagUsers = new HashSet<TagUserObject>();
            Todos = new HashSet<TodoObject>();
        }

        public int? IdCardList { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public int? EstimateTime { get; set; }
        public int? ActualTime { get; set; }
        public string Status { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public int? IdUser { get; set; }

        public virtual CardListObject IdCardListNavigation { get; set; }
        public virtual ICollection<AttachmentObject> Attachments { get; set; }
        public virtual ICollection<CommentObject> Comments { get; set; }
        public virtual ICollection<TagUserObject> TagUsers { get; set; }
        public virtual ICollection<TodoObject> Todos { get; set; }
    }
}