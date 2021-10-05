using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Comment
    {
        public Comment()
        {
            ReplyComments = new HashSet<ReplyComment>();
        }

        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public string Commentor { get; set; }
        public string ContentBody { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public int? IdUser { get; set; }

        public virtual TaskCard IdTaskCardNavigation { get; set; }
        public virtual ICollection<ReplyComment> ReplyComments { get; set; }
    }
}
