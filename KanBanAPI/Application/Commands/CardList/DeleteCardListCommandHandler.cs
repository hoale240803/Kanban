using Domain.AggregatesModel.CardLists;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
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
            // 1. get current user role

            // 2. delete cardlist 

            // 2.1 if the card list is own by current user

            // 2.2 if user role is admin

            
            _cardListRepository.Delete(request._idCardList);
            return await _cardListRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }

    public class DeleteCardListIdentifiedCommandHandler : IdentifiedCommandHandler<DeleteCardListCommand, bool>
    {
        public DeleteCardListIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<DeleteCardListCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}