using Domain.AggregatesModel.TaskCards;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class DragDropTaskCardCommandHandler : IRequestHandler<DragDropTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public DragDropTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(DragDropTaskCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}