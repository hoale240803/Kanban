using Domain.AggregatesModel.TaskCards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class AssignTaskCardCommandHandler : IRequestHandler<AssignTaskCardCommand, bool>
    {
        private readonly ITaskCardRepository _taskCardRepository;
        public AssignTaskCardCommandHandler(ITaskCardRepository taskCardRepository)
        {
            _taskCardRepository = taskCardRepository ?? throw new ArgumentNullException(nameof(_taskCardRepository));
        }
        public async Task<bool> Handle(AssignTaskCardCommand request, CancellationToken cancellationToken)
        {
            var existTaskCard=_taskCardRepository.FindById(request._idTaskCard);

            if (existTaskCard==null)
            {
                string exceptionString= "Not found {0} TaskCard";
                string msg = string.Format(exceptionString, request._idTaskCard);
                throw new Exception(msg);
            }
            _taskCardRepository.AssignTaskCard(request._idUser,request._idTaskCard);
            return await _taskCardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
