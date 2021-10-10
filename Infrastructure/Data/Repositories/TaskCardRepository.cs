using Domain.AggregatesModel.TaskCard;
using Domain.AggregatesModel.TaskCards;
using Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class TaskCardRepository : ITaskCardRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public TaskCardObject Add(TaskCardObject order)
        {
            throw new NotImplementedException();
        }

        public bool AssignTaskCard(int idUser, int idTaskCard)
        {
            throw new NotImplementedException();
        }

        public bool CopyTaskCard(int idCardList, TaskCardObject taskCardObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool DragAndDrop(int idCardlist)
        {
            throw new NotImplementedException();
        }

        public TaskCardObject FindById(int idTaskCard)
        {
            throw new NotImplementedException();
        }

        public Task<TaskCardObject> GetAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool SaveDescription(int taskCard, string description)
        {
            throw new NotImplementedException();
        }

        public bool SetPriority(int taskCard, string priority)
        {
            throw new NotImplementedException();
        }

        public bool Update(TaskCardObject order)
        {
            throw new NotImplementedException();
        }
    }
}