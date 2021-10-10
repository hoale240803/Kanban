using Domain.AggregatesModel.TaskCards;
using Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class PostCommentCommandHandler : IRequestHandler<PostCommentCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;

        public PostCommentCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }

        public Task<bool> Handle(PostCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class PostCommentIdentifiedCommandHandler : IdentifiedCommandHandler<PostCommentCommand, bool>
    {
        public PostCommentIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<PostCommentCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}