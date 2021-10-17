using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class DragDropTaskCardCommand : IRequest<bool>
    {
        public int _idTaskCard { get; set; }
        public decimal _taskOrder { get; set; }
        public string _idUser { get; set; }

        public DragDropTaskCardCommand(int idTaskCard, decimal taskOrder, string idUser)
        {
            _idTaskCard = idTaskCard;
            _taskOrder = taskOrder;
            _idUser = idUser;
        }
    }
}