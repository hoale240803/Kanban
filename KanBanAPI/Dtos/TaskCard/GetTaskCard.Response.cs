using System;
using System.Collections.Generic;

namespace KanBanAPI.Dtos.TaskCard
{
    public class GetTaskCardResponse
    {
        public int Id { get; set; }
        public int? IdCardList { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public int? EstimateTime { get; set; }
        public int? ActualTime { get; set; }
        public string Status { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public int? IdUser { get; set; }
        public string TaggedUserName { get; set; }
        public string AttachmentId { get; set; }

        //public List<TodoDTOResponse> TodoList { get; set; }
        //public List<CommentDTOResponse> CommentList { get; set; }
    }
}