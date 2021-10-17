using Infrastructure.Idempotency;
using KanBanAPI.Application.Commands.CardList;
using KanBanAPI.Application.Commands.TaskCard;
using MediatR;
using Microsoft.Extensions.Logging;
using MiddleMan.EventBus.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands
{
    public class IdentifiedCommandHandler<T, R> : IRequestHandler<IdentifiedCommand<T, R>, R>
        where T : IRequest<R>
    {
        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;
        private readonly ILogger<IdentifiedCommandHandler<T, R>> _logger;

        public IdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<T, R>> logger)
        {
            _mediator = mediator;
            _requestManager = requestManager;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates the result value to return if a previous request was found
        /// </summary>
        /// <returns></returns>
        protected virtual R CreateResultForDuplicateRequest()
        {
            return default(R);
        }

        public async Task<R> Handle(IdentifiedCommand<T, R> message, CancellationToken cancellationToken)
        {
            var alreadyExists = await _requestManager.ExistAsync(message.Id);
            if (alreadyExists)
            {
                return CreateResultForDuplicateRequest();
            }
            else
            {
                await _requestManager.CreateRequestForCommandAsync<T>(message.Id);
                try
                {
                    var command = message.Command;
                    var commandName = command.GetGenericTypeName(); // eventBus project
                    var idProperty = string.Empty;
                    var commandId = string.Empty;

                    switch (command)
                    {
                        case CreateCardListCommand createCardList:
                            idProperty = nameof(createCardList.IdUser);
                            commandId = createCardList.IdUser;
                            break;

                        case CreateTaskCardCommand createTaskCard:
                            idProperty = nameof(createTaskCard._idCardList);
                            commandId = $"{createTaskCard._idUser}";
                            break;

                        //case ShipOrderCommand shipOrderCommand:
                        //    idProperty = nameof(shipOrderCommand.OrderNumber);
                        //    commandId = $"{shipOrderCommand.OrderNumber}";
                        //    break;

                        default:
                            idProperty = "Id?";
                            commandId = "n/a";
                            break;
                    }

                    _logger.LogInformation(
                        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                        commandName,
                        idProperty,
                        commandId,
                        command);

                    //// Send the embeded business command to mediator so it runs its related CommandHandler
                    var result = await _mediator.Send(command, cancellationToken);

                    _logger.LogInformation(
                        "----- Command result: {@Result} - {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                        result,
                        commandName,
                        idProperty,
                        commandId,
                        command);

                    return result;
                }
                catch
                {
                    return default(R);
                }
            }

        }
    }
}