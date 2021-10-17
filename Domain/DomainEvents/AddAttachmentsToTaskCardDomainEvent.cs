using MediatR;

namespace Domain.DomainEvents
{
    public class AddAttachmentsToTaskCardDomainEvent : INotification
    {
        public string _fileName { get; set; }
        public string _fileId { get; set; }
        public string _internalPath { get; set; }
        public string _externalPath { get; set; }
        public string _category { get; set; }

        public AddAttachmentsToTaskCardDomainEvent(string fileName, string fileId,
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