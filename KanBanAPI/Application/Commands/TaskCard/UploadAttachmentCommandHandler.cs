using Domain.AggregatesModel.TaskCards;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class UploadAttachmentCommandHandler : IRequestHandler<UploadAttachmentCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public UploadAttachmentCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(UploadAttachmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}