using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.Todos
{
    public interface ITodoRepository : IRepository<TodoObject>
    {
        TodoObject Add(TodoObject order);

        void Update(TodoObject order);

        Task<TodoObject> GetAsync(int orderId);

        void Delete(string id);
    }
}