using Domain.AggregatesModel.TaskCard;
using Domain.SeedWork;

namespace Domain.AggregatesModel.Attachments
{
    public class AttachmentObject : Entity, IAggregateRoot
    {
        public int? IdTaskCard { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string InternalPath { get; set; }
        public string ExternalPath { get; set; }
        public int? IdComment { get; set; }

        public virtual TaskCardObject IdTaskCardNavigation { get; set; }
    }
}