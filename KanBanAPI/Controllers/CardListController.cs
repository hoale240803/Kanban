using KanBanAPI.Application.Commands;
using KanBanAPI.Application.Commands.CardList;
using KanBanAPI.Application.Commands.TaskCard;
using KanBanAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddleMan.EventBus.Extensions;
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
        public async Task<IActionResult> CreateCardListAsync([FromBody] CreateCardListCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<CreateCardListCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command.IdUser),
                    requestCreateTaskCard.Command.Title,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("update")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateTaskCardAsync([FromBody] UpdateTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestUpdateTaskCard = new IdentifiedCommand<UpdateTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestUpdateTaskCard.GetGenericTypeName(),
                    nameof(requestUpdateTaskCard.Command._idCardList),
                    requestUpdateTaskCard.Command._idUser,
                    requestUpdateTaskCard);

                commandResult = await _mediator.Send(requestUpdateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteTaskCardAsync([FromBody] DeleteTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestDeleteTaskCard = new IdentifiedCommand<DeleteTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestDeleteTaskCard.GetGenericTypeName(),
                    nameof(requestDeleteTaskCard.Command._idTaskCard));

                commandResult = await _mediator.Send(requestDeleteTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("setTitle")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SetTitleCardListAsync([FromBody] SetTitleCardListCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var setTitleRequest = new IdentifiedCommand<SetTitleCardListCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    setTitleRequest.GetGenericTypeName(),
                    nameof(setTitleRequest.Command._idCardList));

                commandResult = await _mediator.Send(setTitleRequest);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}