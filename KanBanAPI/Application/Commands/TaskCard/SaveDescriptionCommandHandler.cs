using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class SaveDescriptionCommandHandler : IRequestHandler<SaveDescriptionCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public SaveDescriptionCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(SaveDescriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class SaveDescriptionIdentifiedCommandHandler : IdentifiedCommandHandler<SaveDescriptionCommand, bool>
    {
        public SaveDescriptionIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<SaveDescriptionCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}