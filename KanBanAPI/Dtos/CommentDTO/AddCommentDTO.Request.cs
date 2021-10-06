using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanAPI.Dtos.Comment
{
    public class AddCommentRequest
    {
        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public string Commentor { get; set; }
        public string ContentBody { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public int? IdUser { get; set; }
    }
}
