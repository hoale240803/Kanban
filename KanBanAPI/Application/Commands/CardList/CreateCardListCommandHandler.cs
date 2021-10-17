using Domain.AggregatesModel.CardLists;
using Domain.DataModels;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.CardList
{
    public class CreateCardListCommandHandler : IRequestHandler<CreateCardListCommand, bool>
    {
        private ICardListRepository _cardListRepository;

        public CreateCardListCommandHandler(ICardListRepository cardListRepository)
        {
            _cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        public async Task<bool> Handle(CreateCardListCommand request, CancellationToken cancellationToken)
        {
            //validate
            // add cardlist
            var cardList = new CardListEntity(request.Title, request.IdUser);
            _cardListRepository.Add(cardList);
            return await _cardListRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }

    public class CreateCardListIdentifiedCommandHandler : IdentifiedCommandHandler<CreateCardListCommand, bool>
    {
        public CreateCardListIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CreateCardListCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}