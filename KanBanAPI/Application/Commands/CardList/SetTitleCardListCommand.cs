using MediatR;

namespace KanBanAPI.Application.Commands.CardList
{
    public class SetTitleCardListCommand : IRequest<bool>
    {
        public string _title { get; set; }

        public SetTitleCardListCommand(string title)
        {
            _title = title;
        }
    }
}