using Domain.AggregatesModel.CardLists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.CardList
{
    public class CreateCardListCommandHandler : IRequestHandler<CreateCardListCommand, bool>
    {
        ICardListRepository _cardListRepository;
        public CreateCardListCommandHandler(ICardListRepository cardListRepository)
        {
            _cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }
        public async Task<bool> Handle(CreateCardListCommand request, CancellationToken cancellationToken)
        {
            //validate
            // add cardlist
            var cardList = new CardListObject(request.Title,request.IdUser);
            _cardListRepository.Add(cardList);
            return await _cardListRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
