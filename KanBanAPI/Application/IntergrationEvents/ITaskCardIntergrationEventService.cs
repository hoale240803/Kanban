
using MiddleMan.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace KanBanAPI.Application.IntergrationEvents
{
    public interface ITaskCardIntergrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);

        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}