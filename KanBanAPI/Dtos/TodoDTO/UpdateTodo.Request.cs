using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanAPI.Dtos.TodoDTO
{
    public class UpdateTodoRequest
    {
        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int IdUser { get; set; }
    }
}
