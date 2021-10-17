using Domain.AggregatesModel.TaskCard;
using Domain.SeedWork;

namespace Domain.AggregatesModel.Attachments
{
    public class AttachmentObject : Entity, IAggregateRoot
    {
        public string _fileName { get; set; }
        public string _fileId { get; set; }
        public string _internalPath { get; set; }
        public string _externalPath { get; set; }
        public string _category { get; set; }

        public virtual TaskCardObject IdTaskCardNavigation { get; set; }

        public AttachmentObject(string fileName, string fileId,
            string internalPath, string externalPath, string category)
        {
            _fileName = fileName;
            _fileId = fileId;
            _internalPath = internalPath;
            _externalPath = externalPath;
            _category = category;
        }
    }
}