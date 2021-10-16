using Domain.AggregatesModel.TaskCard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class UpdateTaskCardCommand : IRequest<bool>
    {
        //[DataMember]
        //public TaskCardObject _taskCard { get; set; }
        public int _idCardList { get; set; }
        public string _title { get; set; }
        public string _priority { get; set; }
        public int _estimateTime { get; set; }
        public int _actualTime { get; set; }
        public string _status { get; set; }
        public DateTime _duedate { get; set; }
        public string _location { get; set; }
        public string _device { get; set; }
        public string _idUser { get; set; }
        public IEnumerable<AttachmentDTO> _attachments { get; set; }
        public IEnumerable<CommentDTO> _comments { get; set; }
        public IEnumerable<string> _taggedUsers { get; set; }
        public IEnumerable<TodoDTO> _todos { get; set; }

        public UpdateTaskCardCommand(int idCardList,string title, string priority, int estimateTime, int actualTime, string status, DateTime duedate, string location, string device, string idUser)
        {
            _idCardList = idCardList;
            _title = title;
            _priority = priority;
            _estimateTime = estimateTime;
            _actualTime = actualTime;
            _status = status;
            _actualTime = actualTime;
            _duedate = duedate;
            _device = device;
            _idUser = idUser;
        }

        public UpdateTaskCardCommand(List<AttachmentDTO> attachments, IEnumerable<CommentDTO> comments, IEnumerable<string> taggedUsers, IEnumerable<TodoDTO> todos)
        {
            _attachments = attachments;
            _comments = comments;
            _taggedUsers = taggedUsers;
            _todos = todos;
        }

        public UpdateTaskCardCommand(List<AttachmentDTO> attachments)
        {
            _attachments = attachments;
        }

        public UpdateTaskCardCommand(List<AttachmentDTO> attachments, IEnumerable<CommentDTO> comments)
        {
            _attachments = attachments;
            _comments = comments;
        }

        public UpdateTaskCardCommand(IEnumerable<string> taggedUsers)
        {
            _taggedUsers = taggedUsers;
        }

        public UpdateTaskCardCommand(IEnumerable<TodoDTO> todos)
        {
            _todos = todos;
        }
    }

    public record CommentDTO
    {
        public int IdTaskCard { get; set; }
        public string Commentor { get; set; }
        public string ContentBody { get; set; }
        public int? IdUser { get; set; }
    }
    public record TodoDTO
    {
        public int IdTaskCard { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public int IdUser { get; set; }
    }
}