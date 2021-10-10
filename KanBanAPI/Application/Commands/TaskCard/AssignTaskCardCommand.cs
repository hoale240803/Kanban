using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class AssignTaskCardCommand : IRequest<bool>
    {
        public int _idUser { get; set; }
        public int _idTaskCard { get; set; }

        public AssignTaskCardCommand(int idUser, int idTaskCard)
        {
            _idUser = idUser;
            _idTaskCard = idTaskCard;
        }
    }
}