using MediatR;

namespace KanBanAPI.Application.Commands.CardList
{
    public class DeleteCardListCommand : IRequest<bool>
    {
        public int _idCardList { get; set; }

        public DeleteCardListCommand(int idCardList)
        {
            _idCardList = idCardList;
        }
    }
}