using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.TaskCard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Queries
{
    public class TaskCardQueries : ITaskCardQueries
    {
        private string _connectionString = string.Empty;

        public TaskCardQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public Task<IEnumerable<CommentObject>> GetCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskCardObject> GetTaskCardAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskCardObject>> GetTaskCardsFromCardListAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}