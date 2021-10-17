using Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class TaskCardEntity : Entity, IAggregateRoot
    {
        public TaskCardEntity()
        {
            Attachments = new HashSet<Attachment>();
            Comments = new HashSet<Comment>();
            TagUsers = new HashSet<TagUser>();
            Todos = new HashSet<Todo>();
        }

        public int Id { get; set; }
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
        public string Description { get; set; }
        public string Label { get; set; }
        public float? TaskCardOrder { get; set; }

        public virtual CardListEntity IdCardListNavigation { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TagUser> TagUsers { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }
    }
}