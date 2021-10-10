using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class SaveDescriptionCommand : IRequest<bool>
    {
        public int IdTaskCard { get; set; }
        public string Descriptions { get; set; }

        public SaveDescriptionCommand(int idTaskCard, string descriptions)
        {
            IdTaskCard = idTaskCard;
            Descriptions = descriptions;
        }
    }
}