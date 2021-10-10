using Domain.AggregatesModel.CardLists;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.CardList
{
    public class SetTitleCardListCommandHandler : IRequestHandler<SetTitleCardListCommand, bool>
    {
        private ICardListRepository _cardListRepository;

        public SetTitleCardListCommandHandler(ICardListRepository cardListRepository)
        {
            _cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        public async Task<bool> Handle(SetTitleCardListCommand request, CancellationToken cancellationToken)
        {
            _cardListRepository.UpdateTitle(request._title);
            return await _cardListRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}