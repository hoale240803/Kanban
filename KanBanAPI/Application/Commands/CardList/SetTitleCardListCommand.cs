using MediatR;

namespace KanBanAPI.Application.Commands.CardList
{
    public class SetTitleCardListCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }
        public string _title { get; set; }
        public string _idUser { get; set; }

        public SetTitleCardListCommand(string title, int idCardList, string idUser)
        {
            _title = title;
            _idCardList = idCardList;
            _idUser = idUser;
        }
    }
}