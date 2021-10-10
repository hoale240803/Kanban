using Domain.AggregatesModel.TaskCard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class UpdateTaskCardCommand : IRequest<bool>
    {
        [DataMember]
        public TaskCardObject _taskCard { get; set; }
    }
}
