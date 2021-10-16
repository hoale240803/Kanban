using MediatR;
using System;

namespace Domain.DomainEvents
{
    public class AddCommentToTaskCardDomainEvent : INotification
    {
        public int _idTaskCard { get; set; }
        public string _contentBody { get; set; }
        public DateTime? _createAt { get; set; }
        public string _createBy { get; set; }
        public DateTime? _updateAt { get; set; }
        public string _updateBy { get; set; }
        public string _idUser { get; set; }

        public AddCommentToTaskCardDomainEvent(int idTaskCard,
            string contentBody, DateTime createAt, DateTime updateAt, string createBy,
            string updateBy, string idUser)
        {
            _idTaskCard = idTaskCard;
            _contentBody = contentBody;
            _createAt = createAt;
            _createBy = createBy;
            _updateAt = DateTime.Now;
            _updateBy = updateBy;
            _idUser = idUser;
        }
    }
}