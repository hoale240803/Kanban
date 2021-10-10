using MediatR;
using System;
using System.Collections.Generic;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class CreateTaskCardCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }
        public string _title { get; set; }
        public string _priority { get; set; }
        public int _estimateTime { get; set; }
        public int _actualTime { get; set; }
        public string _status { get; set; }
        public DateTime _duedate { get; set; }
        public string _location { get; set; }
        public string _device { get; set; }
        public int _idUser { get; set; }

        public IEnumerable<AttachmentDTO> Attachments { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
        public IEnumerable<int> TagUsers { get; set; }
        public IEnumerable<TodoDTO> Todos { get; set; }

        public CreateTaskCardCommand(int idCarlist, string title, string prioriy, int estimateTiem, int actualTime,
            string status, DateTime duedate, string location, string device, int idUser,
            List<AttachmentDTO> attachmentDTOs, List<CommentDTO> commentDTOs, List<TodoDTO> todoDTOs)
        {

        }
    }

    public record AttachmentDTO
    {
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string Category { get; set; }
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