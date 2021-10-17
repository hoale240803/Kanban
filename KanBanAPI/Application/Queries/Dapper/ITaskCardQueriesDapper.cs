using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Queries.Dapper
{
    public interface ITaskCardQueriesDapper
    {
        Task<TaskCardViewModel> GetTaskCardAsync(int id);

        Task<IEnumerable<TaskCardViewModel>> GetTaskCardsFromCardListAsync(Guid userId);

        Task<IEnumerable<CommentViewModel>> GetCommentsAsync(int taskCardId);
    }
}