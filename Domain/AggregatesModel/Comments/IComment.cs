using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.Comments
{
    public interface IComment : IRepository<CommentObject>
    {
        CommentObject Add(CommentObject order);

        void Update(CommentObject order);

        Task<CommentObject> GetAsync(int orderId);

        void Delete(string id);
    }
}