using Domain.DataModels;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.TaskCards
{
    public interface ITaskCardRepository : IRepository<TaskCardEntity>
    {
        TaskCardEntity Add(TaskCardEntity order);

        bool Update(TaskCardEntity order);

        Task<TaskCardEntity> GetAsync(int orderId);

        bool Delete(string id);

        bool AssignTaskCard(int idUser, int idTaskCard);

        bool CopyTaskCard(int idCardList, TaskCardEntity TaskCardEntity);

        bool DragAndDrop(int idCardlist);

        bool SaveDescription(int taskCard, string description);

        bool SetPriority(int taskCard, string priority);

        TaskCardEntity FindById(int idTaskCard);
    }
}