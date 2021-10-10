using Domain.AggregatesModel.TaskCard;
using Domain.SeedWork;
using System;

namespace Domain.AggregatesModel.Todos
{
    public class TodoObject : Entity, IAggregateRoot
    {
        public int? IdTaskCard { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Device { get; set; }
        public string Location { get; set; }
        public int? IdUser { get; set; }

        public virtual TaskCardObject IdTaskCardNavigation { get; set; }
    }
}