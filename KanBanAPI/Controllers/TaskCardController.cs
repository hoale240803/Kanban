using KanBanAPI.Application.Commands;
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
    public class TaskCardController : ControllerBase
    {
        private const HttpStatusCode badRequest = HttpStatusCode.BadRequest;
        private readonly IMediator _mediator;
        private readonly ITaskCardQueries _taskCardQueries;

        //private readonly IIdentityService _identityService;
        private readonly ILogger<CardListController> _logger;

        public TaskCardController(IMediator mediator, ITaskCardQueries taskCardQueries, ILogger<CardListController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _taskCardQueries = taskCardQueries ?? throw new ArgumentNullException(nameof(taskCardQueries));
            //_identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> CreateCardListAsync([FromBody] CreateTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<CreateTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command._idCardList),
                    requestCreateTaskCard.Command._idUser,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("assign")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> AssignTaskCardAsync([FromBody] AssignTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<AssignTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command._idTaskCard),
                    requestCreateTaskCard.Command._idUser,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("copy")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> CopyTaskCardAsync([FromBody] CopyTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<CopyTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command._idCardList),
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("delete")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> DeleteTaskCardAsync([FromBody] DeleteTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<DeleteTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command._idTaskCard),
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("dragdrop")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> DragDropTaskCardAsync([FromBody] DragDropTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<DragDropTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command._idTaskCard),
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("createComment")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> CreateCommentTaskCardAsync([FromBody] PostCommentCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<PostCommentCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command.IdTaskCard),
                    requestCreateTaskCard.Command.IdUser,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("saveDescription")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> SaveDescriptionTaskCardAsync([FromBody] SaveDescriptionCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<SaveDescriptionCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command.IdTaskCard),
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("setPriority")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> SetPriorityTaskCardAsync([FromBody] SetPriorityTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<SetPriorityTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command.IdTaskCard),
                    requestCreateTaskCard.Command.Priority,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("update")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> UpdateTaskCardAsync([FromBody] UpdateTaskCardCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<UpdateTaskCardCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command._taskCard.IdCardList),
                    requestCreateTaskCard.Command._taskCard.Id,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("upload")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> UploadAttachmentForTaskCardAsync([FromBody] UploadAttachmentCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateTaskCard = new IdentifiedCommand<UploadAttachmentCommand, bool>(command, guid);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    requestCreateTaskCard.GetGenericTypeName(),
                    nameof(requestCreateTaskCard.Command.IdTaskCard),
                    requestCreateTaskCard.Command.AttachmentDTO.FileId,
                    requestCreateTaskCard);

                commandResult = await _mediator.Send(requestCreateTaskCard);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(true);
        }
        [Route("{taskCardId:int}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> GetTaskCardByIdAsync(int taskCardId)
        {
            bool commandResult = false;
            var comments = await _taskCardQueries.GetCommentsAsync(taskCardId);
            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(comments);
        }
        [Route("{taskCardId:int}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)badRequest)]
        public async Task<IActionResult> GetTaskCardAsync(int taskCardId)
        {
            bool commandResult = false;
            var taskCard = await _taskCardQueries.GetTaskCardAsync(taskCardId);
            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok(taskCard);
        }

    }
}