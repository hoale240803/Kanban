using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class TaskCardHistory
    {
        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public int? IdTodo { get; set; }
        public int? IdComment { get; set; }
        public int? IdAttachment { get; set; }
        public int? IdTaggedPerson { get; set; }
        public int? IdUser { get; set; }
    }
}
