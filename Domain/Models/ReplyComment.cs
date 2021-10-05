using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class ReplyComment
    {
        public int Id { get; set; }
        public int? IdComment { get; set; }
        public string ContentBody { get; set; }
        public int? IdUser { get; set; }

        public virtual Comment IdCommentNavigation { get; set; }
    }
}
