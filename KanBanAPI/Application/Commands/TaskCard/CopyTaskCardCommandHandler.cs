using Domain.AggregatesModel.TaskCards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
}
