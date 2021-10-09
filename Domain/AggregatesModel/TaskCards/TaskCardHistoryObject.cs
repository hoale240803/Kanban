using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.TaskCards
{
    public class TaskCardHistoryObject: Entity, IAggregateRoot
    {
        public int? IdTaskCard { get; set; }
        public int? IdTodo { get; set; }
        public int? IdComment { get; set; }
        public int? IdAttachment { get; set; }
        public int? IdTaggedPerson { get; set; }
        public int? IdUser { get; set; }
    }
}
