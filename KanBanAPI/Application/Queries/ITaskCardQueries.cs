using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.TaskCard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Queries
{
    public interface ITaskCardQueries
    {
        Task<TaskCardObject> GetTaskCardAsync(int id);

        Task<IEnumerable<TaskCardObject>> GetTaskCardsFromCardListAsync(Guid userId);

        Task<IEnumerable<CommentObject>> GetCommentsAsync();
        Task<IEnumerable<CommentObject>> GetCommentsAsync();
    }
}