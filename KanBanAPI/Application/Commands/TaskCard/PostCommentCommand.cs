using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class PostCommentCommand : IRequest<bool>
    {
        public int IdTaskCard { get; set; }
        public string ContentBody { get; set; }
        public int IdUser { get; set; }

        public PostCommentCommand(int idTaskCard, string contentBody, int idUser)
        {
            IdTaskCard = idTaskCard;
            ContentBody = contentBody;
            IdUser = idUser;
        }
    }
}