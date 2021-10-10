using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class DragDropTaskCardCommand : IRequest<bool>
    {
        public int _idTaskCard { get; set; }

        public DragDropTaskCardCommand(int idTaskCard)
        {
            _idTaskCard = idTaskCard;
        }
    }
}