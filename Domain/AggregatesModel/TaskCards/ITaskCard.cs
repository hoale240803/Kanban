using Domain.AggregatesModel.TaskCard;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.TaskCards
{
    public interface ITaskCard : IRepository<TaskCardObject>
    {
        TaskCardObject Add(TaskCardObject order);

        void Update(TaskCardObject order);

        Task<TaskCardObject> GetAsync(int orderId);

        void Delete(string id);
    }
}