using Domain.AggregatesModel.TaskCards;
using MediatR;
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

        public Task<bool> Handle(CreateTaskCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}