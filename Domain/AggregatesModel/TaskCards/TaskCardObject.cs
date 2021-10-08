using Domain.Comments;
using Domain.SeedWork;
using System.Collections.Generic;

namespace Domain.TaskCard
{
    public class TaskCardObject : Entity, IAggregateRoot
    {
        public TaskCardObject()
        {

        }
        private readonly List<CommentObject> _orderItems;
        public IReadOnlyCollection<CommentObject> OrderItems => _orderItems;


    }
}