using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class DeleteTaskCardCommand : IRequest<bool>
    {
        public int _idTaskCard { get; set; }
        public string _idUser { get; set; }

        public DeleteTaskCardCommand(int idTaskCard, string idUser)
        {
            _idTaskCard = idTaskCard;
            _idUser = idUser;
        }
    }
}