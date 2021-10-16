using MediatR;
using System;

namespace Domain.DomainEvents
{
    public class AddTodosToTaskCardDomainEvent : INotification
    {
        public int? _idTaskCard { get; set; }
        public string _header { get; set; }
        public string _body { get; set; }
        public string _status { get; set; }
        public DateTime? _createAt { get; set; }
        public string _createBy { get; set; }
        public DateTime? _updateAt { get; set; }
        public string _updateBy { get; set; }
        public string _device { get; set; }
        public string _location { get; set; }
        public string _idUser { get; set; }

        public AddTodosToTaskCardDomainEvent(int idTaskCard, string header, string body,
            string statud, DateTime createAt, DateTime updateAt, string createBy, string updateBy,
            string idUser, string device, string location, string status)

        {
            _idTaskCard = idTaskCard;
            _header = header;
            _body = body;
            _status = status;
            _body = body;
            _createAt = createAt;
            _createBy = createBy;
            _updateAt = updateAt;
            _updateBy = updateBy;
            _device = device;
            _location = location;
            _idUser = idUser;
        }
    }
}