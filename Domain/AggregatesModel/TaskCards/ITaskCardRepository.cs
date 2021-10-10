using Domain.AggregatesModel.TaskCard;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.TaskCards
{
    public interface ITaskCardRepository : IRepository<TaskCardObject>
    {
        TaskCardObject Add(TaskCardObject order);

        bool Update(TaskCardObject order);

        Task<TaskCardObject> GetAsync(int orderId);

        bool Delete(string id);

        bool AssignTaskCard(int idUser, int idTaskCard);

        bool CopyTaskCard(int idCardList, TaskCardObject taskCardObject);

        bool DragAndDrop(int idCardlist);

        bool SaveDescription(int taskCard, string description);

        bool SetPriority(int taskCard, string priority);

        TaskCardObject FindById(int idTaskCard);

    }
}