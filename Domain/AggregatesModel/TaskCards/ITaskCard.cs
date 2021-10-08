using Domain.SeedWork;
using Domain.TaskCard;
using System.Threading.Tasks;

namespace Domain.TaskCards
{
    public interface ITaskCard : IRepository<TaskCardObject>
    {
        TaskCardObject Add(TaskCardObject order);

        void Update(TaskCardObject order);

        Task<TaskCardObject> GetAsync(int orderId);

        void Delete(string id);
    }
}