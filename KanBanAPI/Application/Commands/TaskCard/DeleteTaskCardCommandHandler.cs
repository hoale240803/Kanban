using Domain.AggregatesModel.TaskCards;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class DeleteTaskCardCommandHandler : IRequestHandler<DeleteTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public DeleteTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(DeleteTaskCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}