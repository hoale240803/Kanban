using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class UpdateTaskCardCommandHandler : IRequestHandler<UpdateTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public UpdateTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(UpdateTaskCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateTaskCardIdentifiedCommandHandler : IdentifiedCommandHandler<UpdateTaskCardCommand, bool>
    {
        public UpdateTaskCardIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<UpdateTaskCardCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}