using Domain.AggregatesModel.Attachments;
using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.Todos;
using Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Domain.AggregatesModel.TaskCard
{
    public class TaskCardObject : Entity, IAggregateRoot
    {
        //public TaskCardObject()
        //{
        //    Attachments = new HashSet<AttachmentObject>();
        //    Comments = new HashSet<CommentObject>();
        //    TagUsers = new HashSet<TagUserObject>();
        //    Todos = new HashSet<TodoObject>();
        //}

        public int? _idCardList { get; set; }
        public string _title { get; set; }
        public string _priority { get; set; }
        public int? _estimateTime { get; set; }
        public int? _actualTime { get; set; }
        public string _status { get; set; }
        public DateTime? _duedate { get; set; }
        public DateTime? _createAt { get; set; }
        public string _createBy { get; set; }
        public DateTime? _updateAt { get; set; }
        public string _updateBy { get; set; }
        public string _location { get; set; }
        public string _device { get; set; }
        public string _idUser { get; set; }
        public decimal _taskCardOrder { get; set; }

        private readonly List<AttachmentObject> _attachments;
        public IReadOnlyCollection<AttachmentObject> Attachments => _attachments;

        private readonly List<CommentObject> _comments;
        public IReadOnlyCollection<CommentObject> Comments => _comments;

        private readonly List<TodoObject> _todos;
        public IReadOnlyCollection<TodoObject> Todos => _todos;

        public TaskCardObject()
        {
            _attachments = new List<AttachmentObject>();
            _comments = new List<CommentObject>();
            _todos = new List<TodoObject>();
        }
    }
}