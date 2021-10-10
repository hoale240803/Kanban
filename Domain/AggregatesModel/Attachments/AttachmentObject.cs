using Domain.AggregatesModel.TaskCard;
using Domain.SeedWork;

namespace Domain.AggregatesModel.Attachments
{
    public class AttachmentObject : Entity, IAggregateRoot
    {
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string InternalPath { get; set; }
        public string ExternalPath { get; set; }
        public string Category { get; set; }

        public virtual TaskCardObject IdTaskCardNavigation { get; set; }
    }
}