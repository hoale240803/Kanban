using Domain.AggregatesModel.TaskCards;
using MediatR;
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
}