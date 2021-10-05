using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class TaggedPerson
    {
        public TaggedPerson()
        {
            TaskCardHistories = new HashSet<TaskCardHistory>();
        }

        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public int? IdUser { get; set; }
        public string Name { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        public virtual TaskCard IdTaskCardNavigation { get; set; }
        public virtual ICollection<TaskCardHistory> TaskCardHistories { get; set; }
    }
}
