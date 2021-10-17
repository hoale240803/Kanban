using MediatR;
using System.Runtime.Serialization;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class CreateTaskCardCommand : IRequest<bool>
    {
        [DataMember]
        public int _idCardList { get; set; }
        [DataMember]
        public string _title { get; set; }

        //public string _priority { get; set; }
        //public int _estimateTime { get; set; }
        //public int _actualTime { get; set; }
        //public string _status { get; set; }
        //public DateTime _duedate { get; set; }
        //public string _location { get; set; }
        //public string _device { get; set; }
        [DataMember]
        public string _idUser { get; set; }

        //public IEnumerable<AttachmentDTO> _attachments { get; set; }
        //public IEnumerable<CommentDTO> _comments { get; set; }
        //public IEnumerable<string> _taggedUsers { get; set; }
        //public IEnumerable<TodoDTO> _todos { get; set; }

        //public CreateTaskCardCommand(int idCarlist, string title, string prioriy, int estimateTime, int actualTime,
        //    string status, DateTime duedate, string location, string device, string idUser,
        //    List<AttachmentDTO> attachmentDTOs, List<CommentDTO> commentDTOs, List<TodoDTO> todoDTOs, List<string> taggedUsers)
        //{
        //    _idCardList = idCarlist;
        //    _title = title;
        //    _priority = prioriy;
        //    _estimateTime = estimateTime;
        //    _actualTime = actualTime;
        //    _status = status;
        //    _duedate = duedate;
        //    _location = location;
        //    _device = device;
        //    _idUser = idUser;
        //    _attachments = attachmentDTOs;
        //    _comments = commentDTOs;
        //    _taggedUsers = taggedUsers;
        //    _todos = todoDTOs;
        //}
        //public CreateTaskCardCommand(int idCarlist, string title, string idUser)
        //{
        //    _idCardList = idCarlist;
        //    _title = title;
        //    _idUser = idUser;
        //}
        public CreateTaskCardCommand(int idCarlist, string idUser, string title)
        {
            _idCardList = idCarlist;
            _title = title;
            _idUser = idUser;
        }
    }

    //public record AttachmentDTO
    //{
    //    public string FileName { get; set; }
    //    public string FileId { get; set; }
    //    public string Category { get; set; }
    //}
    //public record CommentDTO
    //{
    //    public int IdTaskCard { get; set; }
    //    public string Commentor { get; set; }
    //    public string ContentBody { get; set; }
    //    public int? IdUser { get; set; }
    //}
    //public record TodoDTO
    //{
    //    public int IdTaskCard { get; set; }
    //    public string Header { get; set; }
    //    public string Body { get; set; }
    //    public string Status { get; set; }
    //    public int IdUser { get; set; }
    //}
}