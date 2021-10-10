using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class SetPriorityTaskCardCommand : IRequest<bool>
    {
        public int IdTaskCard { get; set; }
        public string Priority { get; set; }

        public SetPriorityTaskCardCommand(int idTaskCard, string priority)
        {
            IdTaskCard = idTaskCard;
            Priority = priority;
        }
    }
}