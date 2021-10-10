using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class AssignTaskCardCommandHandler : IRequestHandler<AssignTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public AssignTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public async Task<bool> Handle(AssignTaskCardCommand request, CancellationToken cancellationToken)
        {
            var existTaskCard = _taskCardRepository.FindById(request._idTaskCard);

            if (existTaskCard == null)
            {
                string exceptionString = "Not found {0} TaskCard";
                string msg = string.Format(exceptionString, request._idTaskCard);
                throw new Exception(msg);
            }
            _taskCardRepository.AssignTaskCard(request._idUser, request._idTaskCard);
            return await _taskCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }

    public class AssignTaskCardIdentifiedCommandHandler : IdentifiedCommandHandler<AssignTaskCardCommand, bool>
    {
        public AssignTaskCardIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<AssignTaskCardCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}