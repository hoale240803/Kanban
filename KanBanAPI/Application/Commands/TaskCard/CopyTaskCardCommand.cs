using Domain.DataModels;
using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class CopyTaskCardCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }
        public TaskCardEntity _taskCard { get; set; }

        public CopyTaskCardCommand(int idCardList, TaskCardEntity taskCard)
        {
            _idCardList = idCardList;
            _taskCard = taskCard;
        }
    }
}