using MediatR;

namespace KanBanAPI.Application.Commands.CardList
{
    public class DeleteCardListCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }
        public string _idUser { get; set; }

        public DeleteCardListCommand(int idCardList, string idUser)
        {
            _idCardList = idCardList;
            _idUser = idUser;
        }
    }
}