using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanAPI.Dtos.Attachment
{
    public class AttachmentRequest
    {
        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string InternalPath { get; set; }
        public string ExternalPath { get; set; }
        public int? IdComment { get; set; }
    }
}
