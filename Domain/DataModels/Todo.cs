using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class Todo
    {
        public int Id { get; set; }
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

        public virtual TaskCardEntity IdTaskCardNavigation { get; set; }
    }
}
