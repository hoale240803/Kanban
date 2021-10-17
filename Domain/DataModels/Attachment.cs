using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class Attachment
    {
        public int Id { get; set; }
        public int? IdTaskCard { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string InternalPath { get; set; }
        public string ExternalPath { get; set; }
        public int? IdComment { get; set; }

        public virtual TaskCardEntity IdTaskCardNavigation { get; set; }
    }
}
