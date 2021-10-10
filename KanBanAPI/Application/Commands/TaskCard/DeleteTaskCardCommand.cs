using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class DeleteTaskCardCommand : IRequest<bool>
    {
        public int _idTaskCard { get; set; }

        public DeleteTaskCardCommand(int idTaskCard)
        {
            _idTaskCard = idTaskCard;
        }
    }
}