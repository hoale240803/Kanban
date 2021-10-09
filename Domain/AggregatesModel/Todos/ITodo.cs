using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.Todos
{
    public interface ITodo : IRepository<TodoObject>
    {
        TodoObject Add(TodoObject order);

        void Update(TodoObject order);

        Task<TodoObject> GetAsync(int orderId);

        void Delete(string id);
    }
}
