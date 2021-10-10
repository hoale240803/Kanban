using MediatR;

namespace KanBanAPI.Application.Commands.CardList
{
    public class SetTitleCardListCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }
        public string _title { get; set; }

        public SetTitleCardListCommand(string title, int idCardList)
        {
            _title = title;
            _idCardList = idCardList;
        }
    }
}