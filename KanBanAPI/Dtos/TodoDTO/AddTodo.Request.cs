using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanAPI.Dtos.TodoDTO
{
    public class AddTodoRequest
    {
        public int Id { get; set; }
        public int IdTaskCard { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int IdUser { get; set; }
        //public string Status { get; set; }
        //public DateTime? CreateAt { get; set; }
        //public string CreateBy { get; set; }
        //public DateTime? UpdateAt { get; set; }
        //public string UpdateBy { get; set; }
        //public string Device { get; set; }
        //public string Location { get; set; }

    }
}
