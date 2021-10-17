using Domain.AggregatesModel.TaskCard;
using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class CreateTaskCardCommandHandler : IRequestHandler<CreateTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public CreateTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public async Task<bool> Handle(CreateTaskCardCommand request, CancellationToken cancellationToken)
        {

            var taskCard = new TaskCardObject
            {
                _title = request._title,
                _idCardList = request._idCardList 
            };
            _taskCardRepository.Add(taskCard);
            return await _taskCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }

    public class CreateTaskCardIdentifiedCommandHandler : IdentifiedCommandHandler<CreateTaskCardCommand, bool>
    {
        public CreateTaskCardIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CreateTaskCardCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}