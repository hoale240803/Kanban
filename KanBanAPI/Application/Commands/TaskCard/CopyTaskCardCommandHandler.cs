using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class CopyTaskCardCommandHandler : IRequestHandler<CopyTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public CopyTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public async Task<bool> Handle(CopyTaskCardCommand request, CancellationToken cancellationToken)
        {
            _taskCardRepository.CopyTaskCard(request._idCardList, request._taskCard);
            return await _taskCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }

    public class CopyTaskCardIdentifiedCommandHandler : IdentifiedCommandHandler<CopyTaskCardCommand, bool>
    {
        public CopyTaskCardIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CopyTaskCardCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}