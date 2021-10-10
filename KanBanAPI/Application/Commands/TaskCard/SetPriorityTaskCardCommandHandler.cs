using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class SetPriorityTaskCardCommandHandler : IRequestHandler<SetPriorityTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public SetPriorityTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(SetPriorityTaskCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public class SetPriorityTaskCardIdentifiedCommandHandler : IdentifiedCommandHandler<SetPriorityTaskCardCommand, bool>
        {
            public SetPriorityTaskCardIdentifiedCommandHandler(
                IMediator mediator,
                IRequestManager requestManager,
                ILogger<IdentifiedCommandHandler<SetPriorityTaskCardCommand, bool>> logger)
                : base(mediator, requestManager, logger)
            {
            }

            protected override bool CreateResultForDuplicateRequest()
            {
                return true;                // Ignore duplicate requests for processing order.
            }
        }
    }
}