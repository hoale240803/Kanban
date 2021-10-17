using Domain.AggregatesModel.Attachments;
using Domain.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.DomainEventHandlers.AddAttachmentsToTaskCard
{
    public class AddAttachmentsToTaskCardDomainHandler : INotificationHandler<AddAttachmentsToTaskCardDomainEvent>
    {
        private readonly ILoggerFactory _logger;
        private readonly IAttachmentRepository _attachmentRepository;
        //private readonly IIdentityService _identityService;
        //private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;

        public AddAttachmentsToTaskCardDomainHandler(
            ILoggerFactory logger,
            IAttachmentRepository attachmentRepository)
        {
            //_buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            //_identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            //_orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _attachmentRepository = attachmentRepository ?? throw new ArgumentNullException(nameof(attachmentRepository));
        }

        public async Task Handle(AddAttachmentsToTaskCardDomainEvent addAttachmentToTaskCardEvent, CancellationToken cancellationToken)
        {
            // 1. upload file
            // 2.
            var attachmentToAdd = new AttachmentObject(
                addAttachmentToTaskCardEvent._internalPath,
                addAttachmentToTaskCardEvent._fileName,
                addAttachmentToTaskCardEvent._fileId,
                addAttachmentToTaskCardEvent._externalPath,
                addAttachmentToTaskCardEvent._category)
                ;

            _attachmentRepository.Add(attachmentToAdd);
        }
    }
}