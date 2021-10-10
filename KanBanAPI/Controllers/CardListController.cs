using KanBanAPI.Application.Commands;
using KanBanAPI.Application.Commands.TaskCard;
using KanBanAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace KanBanAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardListController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITaskCardQueries _taskCardQueries;

        //private readonly IIdentityService _identityService;
        private readonly ILogger<CardListController> _logger;

        public CardListController(IMediator mediator, ITaskCardQueries taskCardQueries, ILogger<CardListController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _taskCardQueries = taskCardQueries ?? throw new ArgumentNullException(nameof(taskCardQueries));
            //_identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CancelOrderAsync([FromBody] CreateTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<CreateTaskCardCommand, bool>(command, guid);

                //_logger.LogInformation(
                //    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                //    requestCancelOrder.GetGenericTypeName(),
                //    nameof(requestCancelOrder.Command.OrderNumber),
                //    requestCancelOrder.Command.OrderNumber,
                //    requestCancelOrder);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}