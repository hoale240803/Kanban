using System;
using System.Collections.Generic;

namespace KanBanAPI.Application.Queries
{
    public record TaskCardViewModel
    {
        public int IdCardList { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public int EstimateTime { get; set; }
        public int ActualTime { get; set; }
        public string Status { get; set; }
        public DateTime Duedate { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }

        public List<AttachmentViewModel> Attachments { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<TaggedUserViewModel> TaggedUsers { get; set; }
        public List<HashTagLabelViewModel> Labels { get; set; }
        public List<TaskCardHistoryViewModel> Histories {get;set;}
    }
    public record CommentViewModel
    {
        public int IdComment { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
    }
    public record TaggedUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public record AttachmentViewModel
    {
        public int IdAttachment { get; set; }
        public string FileId { get; set; }
        public string Path { get; set; }
        public string Category { get; set; }
    }
    public record HashTagLabelViewModel
    {
        public int IdLabel { get; set; }
        public string Title { get; set; }
    }
    public record TaskCardHistoryViewModel
    {
        public int IdHistory { get; set; }
        public string Content { get; set; }
    }
}