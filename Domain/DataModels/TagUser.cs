using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class TagUser
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int? IdTaskCard { get; set; }
        public string Name { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string TypeOfTag { get; set; }

        public virtual TaskCardEntity IdTaskCardNavigation { get; set; }
    }
}
