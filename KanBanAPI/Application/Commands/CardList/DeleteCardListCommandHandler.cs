using Domain.AggregatesModel.CardLists;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.CardList
{
    public class DeleteCardListCommandHandler : IRequestHandler<DeleteCardListCommand, bool>
    {
        private readonly ICardListRepository _cardListRepository;

        public DeleteCardListCommandHandler(ICardListRepository cardListRepository)
        {
            _cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        public async Task<bool> Handle(DeleteCardListCommand request, CancellationToken cancellationToken)
        {
            _cardListRepository.Delete(request._idCardList);
            return await _cardListRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}