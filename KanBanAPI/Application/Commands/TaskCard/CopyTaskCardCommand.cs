using Domain.AggregatesModel.TaskCard;
using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class CopyTaskCardCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }
        public TaskCardObject _taskCard { get; set; }

        public CopyTaskCardCommand(int idCardList, TaskCardObject taskCard)
        {
            _idCardList = idCardList;
            _taskCard = taskCard;
        }
    }
}